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
using System.Data.OleDb;
using System.Data;

namespace Proyecto
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        OleDbConnection con; //Agregamos la conexión
        DataTable dt; //Agregar la tabla

        public MainWindow()
        {
            InitializeComponent();
            cbMostrar.IsEnabled = false;
            btnMostrar.IsEnabled = false;
            btnView.IsEnabled = false;
            con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.Jet.Oledb.4.0; Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\Music.mdb";
            MostrarDatos();
        }

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd.Connection = con;
            if (txtId.Text != "")
            {
                if (tbId.IsEnabled == true)
                {
                    if (cbAddGeneros.Text != "Género de la canción...")
                    {
                        cmd.CommandText = "insert into MyMusic(Id,Titulo,Artista,Genero,Lista,Link) " +
                            "Values('" + tbId.Text + "','" + tbTitulo.Text + "','" + tbArtista.Text + "','" + cbAddGeneros.Text + "','" + cbAddToLista.Text + "','" + tbLink.Text + "')";
                        cmd.ExecuteNonQuery();
                        MostrarDatos();
                        MessageBox.Show("Canción agregada correctamente...");
                        LimpiarTodo();
                    }
                    else
                    {
                        MessageBox.Show("Favor de seleccionar el genero de la canción...");
                    }
                }
                else
                {
                    cmd.CommandText = "update MyMusic set Titulo='" + tbTitulo.Text + "', Artista = '" + tbArtista.Text + "', Genero='" + cbAddGeneros.Text + "', Lista = '" + cbAddToLista.Text + "', Link= '" + tbLink.Text + "' where Id=" + tbId.Text.ToString();
                    cmd.ExecuteNonQuery();
                    MostrarDatos();
                    MessageBox.Show("Música actualizada...");
                    LimpiarTodo();
                }
            }
            else
            {
                MessageBox.Show("Favor de poner el ID  de un Alumno...");
            }
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (gvMusic.SelectedItems.Count > 0)
            {
                DataRowView row = (DataRowView)gvMusic.SelectedItems[0];
                tbId.Text = row["Id"].ToString();
                tbTitulo.Text = row["Titulo"].ToString();
                tbArtista.Text = row["Artista"].ToString();
                cbAddGeneros.Text = row["Genero"].ToString();
                cbAddToLista.Text = row["Lista"].ToString();
                tbLink.Text = row["Link"].ToString();
                tbId.IsEnabled = false;
                btnAdd.Content = "Actualizar";
                btnEliminar.Content = "Cancelar";
            }
            else
            {
                MessageBox.Show("Favor de seleccionar una canción...");
            }
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (gvMusic.SelectedItems.Count > 0)
            {
                if (btnEliminar.Content.ToString() != "Cancelar")
                {
                    DataRowView row = (DataRowView)gvMusic.SelectedItems[0];
                    OleDbCommand cmd = new OleDbCommand();
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "delete from MyMusic where Id=" + row["Id"].ToString();
                    cmd.ExecuteNonQuery();
                    MostrarDatos();
                    MessageBox.Show("Canción eliminada correctamente...");
                    LimpiarTodo();
                }
                else
                {
                    MessageBox.Show("Se canceló la edición...");
                    LimpiarTodo();
                    btnAdd.Content = "Agregar";
                    btnEliminar.Content = "Eliminar";
                }
            }
            else
            {
                MessageBox.Show("Favor de seleccionar un Equipo...");
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarTodo();
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
            if (cbGeneros.IsEnabled == true || cbListas.IsEnabled == true)
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
            
        }

        //A PARTIR DE AQUÍ YA NO SE TOCA
        private void BtnView_Click(object sender, RoutedEventArgs e)
        {
            Ver();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Agregar();
        }

        private void Agregar()
        {
            tbTitulo.Visibility = System.Windows.Visibility.Visible;
            txtTitulo.Visibility = System.Windows.Visibility.Visible;
            tbArtista.Visibility = System.Windows.Visibility.Visible;
            txtArtista.Visibility = System.Windows.Visibility.Visible;
            cbAddGeneros.Visibility = System.Windows.Visibility.Visible;
            cbAddToLista.Visibility = System.Windows.Visibility.Visible;
            tbLink.Visibility = System.Windows.Visibility.Visible;
            txtLink.Visibility = System.Windows.Visibility.Visible;
            btnAdd.Visibility = System.Windows.Visibility.Visible;
            btnEliminar.Visibility = System.Windows.Visibility.Visible;
            wbVideo.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Ver()
        {
            tbTitulo.Visibility = System.Windows.Visibility.Hidden;
            txtTitulo.Visibility = System.Windows.Visibility.Hidden;
            tbArtista.Visibility = System.Windows.Visibility.Hidden;
            txtArtista.Visibility = System.Windows.Visibility.Hidden;
            cbAddGeneros.Visibility = System.Windows.Visibility.Hidden;
            cbAddToLista.Visibility = System.Windows.Visibility.Hidden;
            tbLink.Visibility = System.Windows.Visibility.Hidden;
            txtLink.Visibility = System.Windows.Visibility.Hidden;
            btnAdd.Visibility = System.Windows.Visibility.Hidden;
            btnEliminar.Visibility = System.Windows.Visibility.Hidden;
            wbVideo.Visibility = System.Windows.Visibility.Visible;
        }

        private void LimpiarTodo()
        {
            tbId.Text = "";
            tbTitulo.Text = "";
            tbArtista.Text = "";
            cbAddGeneros.SelectedIndex = 0;
            cbAddToLista.SelectedIndex = 0;
            tbLink.Text = "";
            tbId.IsEnabled = true;
        }

        private void MostrarDatos()
        {
            OleDbCommand cmd = new OleDbCommand();
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from MyMusic";
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            gvMusic.ItemsSource = dt.AsDataView();
            if (dt.Rows.Count > 0)
            {
                lbContenido.Visibility = System.Windows.Visibility.Hidden;
                gvMusic.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                lbContenido.Visibility = System.Windows.Visibility.Visible;
                gvMusic.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void BtnAddLista_Click(object sender, RoutedEventArgs e)
        {
            tbNewList.Visibility = System.Windows.Visibility.Visible;
            btnAddList.Visibility = System.Windows.Visibility.Visible;
        }

        private void BtnAddList_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
