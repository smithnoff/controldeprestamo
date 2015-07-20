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
       
        public MainWindow()
        {
            InitializeComponent();
        }

       
      async private void Button_Click(object sender, RoutedEventArgs e)
        {

            //Activando el progress ring
            this.prog_ring_star.IsActive = true;

            int flag = 0;
            foreach (usuario u in s.user())
            {
                if (u.asUsername == tbUsername.Text && u.asPassword == tbPassword.Password)
                {
                    this.Close();
                    m.Show();                    
                    flag++;
                }                
            }

            if (flag == 0)
            {
                await this.ShowMessageAsync("Error!", "Usuario o Contraseña Invalida..");                  
            }
           
        }

    }
}
