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
namespace capaVista
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        dbControlCobranzasEntities context = new dbControlCobranzasEntities();
       
        public MainWindow()
        {
            InitializeComponent();



            var query = context.personas.Where(p => p.pkPersonaID == 23589144).FirstOrDefault();

            txtbu.Text = query.asNombre.ToString();
         

        }

       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            
           
        }

    }
}
