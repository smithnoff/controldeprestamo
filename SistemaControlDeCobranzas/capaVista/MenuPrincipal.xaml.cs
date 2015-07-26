#region usings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using CapaNegocio; 
#endregion

namespace capaVista
{
    /// <summary>
    /// Interaction logic for MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : MetroWindow
    {
        #region Propiedades
        sesion s = new sesion();        
        System.Windows.Data.CollectionViewSource usuariosViewSource;
        System.Windows.Data.CollectionViewSource ubicacionsViewSource;
        #endregion

        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {

            #region LoadUsuariosData
            usuariosViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("usuariosViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            usuariosViewSource.Source = s.user().ToArray();
            ubicacionsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("ubicacionsViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            ubicacionsViewSource.Source = s.ciudades().ToArray(); 
            #endregion
        }

        #region BotonesCRUDclientes
        async private void btSave_Click(object sender, RoutedEventArgs e)
        {
            bool exFlag = false;
            try
            {
                s.addCliente(asCedulaTextBox.Text, asNombreTextBox.Text,
                             asApellidoTextBox.Text, 2, Int32.Parse(fkUbicacionIDTextBox.Text));

                btNext.IsEnabled = true;
                btPrevious.IsEnabled = true;
                btUpdate.IsEnabled = true;
                btSave.IsEnabled = false;
                usuariosViewSource.View.MoveCurrentToLast();
                await this.ShowMessageAsync("Exito!", "Se ha Creado el Cliente");
            }
            catch (Exception ex)
            {
                exFlag = true;
            }

            if (exFlag)
            {
                await this.ShowMessageAsync("Error!", "No se ha podido Crear el Cliente");
            }
        }

        private void btPrevious_Click(object sender, RoutedEventArgs e)
        {
            usuariosViewSource.View.MoveCurrentToPrevious();
        }

        private void btNext_Click(object sender, RoutedEventArgs e)
        {
            usuariosViewSource.View.MoveCurrentToNext();
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            s.updateUsuarios(Convert.ToInt32(pkUsuariosIDTextBox.Text),asCedulaTextBox.Text, 
                             asNombreTextBox.Text,asApellidoTextBox.Text,
                             Int32.Parse(fkUbicacionIDTextBox.Text));           
        }

        private void btNew_Click(object sender, RoutedEventArgs e)
        {
            btNext.IsEnabled = false;
            btPrevious.IsEnabled = false;
            btUpdate.IsEnabled = false;
            btSave.IsEnabled = true;

            asCedulaTextBox.Text = "";
            asNombreTextBox.Text = "";
            asApellidoTextBox.Text = "";
            asCiudadesComboBox.SelectedIndex = -1;
        } 
        #endregion
  
        #region UbicacionesTBEventos
        private void fkUbicacionIDTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            pkUbicacionIDTextBox.Text = fkUbicacionIDTextBox.Text;
        }

        private void asCiudadesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fkUbicacionIDTextBox.Text = pkUbicacionIDTextBox.Text;
        }

        private void pkUbicacionIDTextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(pkUbicacionIDTextBox.Text))
            {
                asCiudadesComboBox.SelectedIndex = -1;
            }
            else
            {
                asCiudadesComboBox.SelectedIndex = Int32.Parse(pkUbicacionIDTextBox.Text) - 1;
            }

        } 
        #endregion

        #region BotonesCRUDUbicaciones
        private void btNewU_Click(object sender, RoutedEventArgs e)
        {            
            btNextU.IsEnabled = false;
            btPreviousU.IsEnabled = false;
            btUpdateU.IsEnabled = false;
            btSaveU.IsEnabled = true;

            asCiudadesTextBox.Text = string.Empty;
        }

        private void btNextU_Click(object sender, RoutedEventArgs e)
        {            
            usuariosViewSource.View.MoveCurrentToNext();
        }

        private void btPreviousU_Click(object sender, RoutedEventArgs e)
        {
            usuariosViewSource.View.MoveCurrentToPrevious();
        }

        private void btUpdateU_Click(object sender, RoutedEventArgs e)
        {
            s.updateUbicaciones(Convert.ToInt32(pkUbicacionIDTextBox.Text), asCiudadesTextBox.Text);
        }

        async private void btSaveU_Click(object sender, RoutedEventArgs e)
        {
            bool exFlag = false;
            try
            {
                s.addUbicaciones(asCiudadesTextBox.Text);

                btNextU.IsEnabled = true;
                btPreviousU.IsEnabled = true;
                btUpdateU.IsEnabled = true;
                btSaveU.IsEnabled = false;
                ubicacionsViewSource.View.MoveCurrentToLast();
                
                await this.ShowMessageAsync("Exito!", "Se ha Creado la Ubicacion");
            }
            catch (Exception ex)
            {
                exFlag = true;
            }

            if (exFlag)
            {
                await this.ShowMessageAsync("Error!", "No se ha podido Crear la Ubicacion");
            }
            
        } 
        #endregion

    }
}
