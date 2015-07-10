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
        sesion w = new sesion();
       
        public MainWindow()
        {
            InitializeComponent();

            foreach (persona u in w.user())
            {
                if (u.pkPersonaID == 23589144)
                {
                    tbUsername.Text = u.asNombre + " " + u.asApellido;
                    tbPassword.Password = u.pkPersonaID.ToString();
                }
            }

            
         

        }

       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            
           
        }

    }
}
