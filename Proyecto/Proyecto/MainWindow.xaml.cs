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

namespace Proyecto
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CbMostrar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void CbMostrar_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private void CbMostrar_LostFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void Grid_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            btnElegir.Visibility = System.Windows.Visibility.Visible;
            if (cbGeneros.IsEnabled == true || cbListas.IsEnabled == true )
            {
                if (cbMostrar.Text == "Géneros")
                {
                    cbGeneros.Visibility = System.Windows.Visibility.Visible;
                    cbListas.Visibility = System.Windows.Visibility.Hidden;
                }
                else if (cbMostrar.Text == "Listas de reproduccion")
                {
                    cbListas.Visibility = System.Windows.Visibility.Visible;
                    cbGeneros.Visibility = System.Windows.Visibility.Hidden;
                }
                else
                {

                }
            }
        }

        private void BtnElegir_Click(object sender, RoutedEventArgs e)
        {
            if (cbGeneros.IsEnabled == true || cbListas.IsEnabled == true)
            {
                if (cbMostrar.Text == "Géneros")
                {

                }
                else if (cbMostrar.Text == "Listas de reproduccion")
                {
                    
                }
                else
                {

                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Agregar add = new Agregar();
            add.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
