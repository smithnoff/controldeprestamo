using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Data.SqlClient;
using System.Windows.Threading;
using CapaModelo;
using CapaNegocio;
namespace capaVista
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        sesion s = new sesion();
        MenuPrincipal m = new MenuPrincipal();
        DispatcherTimer loadTimer = new DispatcherTimer();
       
        public MainWindow()
        {
            InitializeComponent();

            loadTimer.Tick += new EventHandler(load_Tick);
            loadTimer.Interval = new TimeSpan(0, 0, 5);
            
        }

       async private void load_Tick(object sender, EventArgs e)
        {
            int flag = 0;
            foreach (usuarios u in s.user())
            {
                if (u.asUsername == tbUsername.Text && u.asPassword == tbPassword.Password)
                {
                    loadTimer.Stop();
                    loginProgRing.Visibility = Visibility.Collapsed;
                    this.Close();
                    m.Show();
                    flag++;
                }
            }

            if (flag == 0)
            {
                await this.ShowMessageAsync("Error!", "Usuario o Contraseña Invalida..");
                loginProgRing.Visibility = Visibility.Collapsed;
                loadTimer.Stop();
            }
        }

       
      private void Button_Click(object sender, RoutedEventArgs e)
        {

            //Activando el progress ring
            //this.prog_ring_star.IsActive = true;
            loginProgRing.Visibility = Visibility.Visible;
            loadTimer.Start();
           
        }

    }
}
