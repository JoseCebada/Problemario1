﻿using System;
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
using System.Data.OleDb;
using System.Data;

namespace Proyecto
{
    /// <summary>
    /// Lógica de interacción para Agregar.xaml
    /// </summary>
    public partial class Agregar : Window
    {

        OleDbConnection con; //Agregamos la conexión
        DataTable dt; //Agregar la tabla

        public Agregar()
        {
            InitializeComponent();
        }

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {

        }

       
    }
}
