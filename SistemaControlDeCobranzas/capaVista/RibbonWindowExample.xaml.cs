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
using System.Windows.Shapes;
using Microsoft.Windows.Controls.Ribbon;

namespace capaVista
{
    /// <summary>
    /// Interaction logic for RibbonWindowExample.xaml
    /// </summary>
    public partial class RibbonWindowExample : RibbonWindow
    {
        
        public RibbonWindowExample()
        {
            InitializeComponent();
        }

        private void RibbonButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hola Aqui Estoy");
        }

        private void btImprimir_Click(object sender, RoutedEventArgs e)
        {
            GridImprimir.Visibility = Visibility.Visible;
        }

        private void closeImprimir_Click(object sender, RoutedEventArgs e)
        {
            GridImprimir.Visibility = Visibility.Collapsed;
        }
    }
}
