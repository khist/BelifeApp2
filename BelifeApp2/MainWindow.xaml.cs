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
using BelifeLibrary;

namespace BelifeApp2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private ClienteCollection _clienteCollection 
            = new ClienteCollection();
        private EstadoCivilCollection _estadoCivilCollection
            = new EstadoCivilCollection();
        //en esta variable se guardará la ventana completa
        public static MainWindow ventanaPrincipal;

        /*
         * Este metodo nos servirá para saber
         * si la ventana ya esta creada o no
         * */
        public static MainWindow getInstance()
        {
            if(ventanaPrincipal == null)
            {
                ventanaPrincipal = new MainWindow();
            }

            return ventanaPrincipal;
        }


        public ClienteCollection ClienteCollection
        {
            get
            {
                return _clienteCollection;
            }

            set
            {
                _clienteCollection = value;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            //apenas se cargue la ventana se cargará el combobox estado civil
            cboEstadoCivil.ItemsSource = this._estadoCivilCollection.ReadAll();
            cboEstadoCivil.SelectedIndex = 0;
        }

        public void CargarGrilla()
        {
            //este metodo nos servirá para cargar o refrescar
            //la grilla(tabla de clientes)
            //primero dejamos la grilla sin datos para refrescarla
            dgClientes.ItemsSource = null;
            //le pasamos los datos a la grilla
            dgClientes.ItemsSource = ClienteCollection.ReadAll();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Rut = txtRut.Text;
            cliente.Nombres = txtNombres.Text;
            cliente.Apellidos = txtApellidos.Text;
            cliente.FechaNacimiento = dpFechaNacimiento.SelectedDate.Value;
            //operador ternario: es un if corto que evaluea una condicion dentro
            //del parentesis si es verdadera devuelve lo que esta despues
            //del signo de interrogacion, si es falsa devuelve 
            //lo que esta despues de los dos puntos
            cliente.Sex = (rbtHombre.IsChecked == true) ? 0 : 1;
           // EstadosCivil d = (EstadosCivil)cboEstadoCivil.SelectedItem;
            cliente.EstadoCivilId = int.Parse(cboEstadoCivil.SelectedValue.ToString());

            if(this.ClienteCollection.InsertarCliente(cliente))
            {
                MessageBox.Show("Agregado correctamente");
            }
            else
            {
                MessageBox.Show("Este cliente ya existe");
            }
            CargarGrilla();

        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            string rut = txtRut.Text;

            Cliente cliente = ClienteCollection.BuscarClientePorRut(rut);

            if(cliente == null)
            {
                MessageBox.Show("El cliente no existe");
                return;
            }

            txtNombres.Text = cliente.Nombres;
            txtApellidos.Text = cliente.Apellidos;
            dpFechaNacimiento.SelectedDate = cliente.FechaNacimiento;
            cboEstadoCivil.SelectedValue = cliente.EstadoCivilId;

            if(cliente.Sex == 0)
            {
                rbtHombre.IsChecked = true;
            }
            else
            {
                rbtMujer.IsChecked = true;
            }

        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtRut.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            dpFechaNacimiento.SelectedDate = DateTime.Today;

            cboEstadoCivil.SelectedIndex = 0;
            rbtHombre.IsChecked = true;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            string rut = txtRut.Text;
            if(ClienteCollection.EliminarClientes(rut))
            {
                MessageBox.Show("Eliminado correctamente");
                CargarGrilla();
            }
            else
            {
                MessageBox.Show("No existe el cliente");
            }
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            string rut = txtRut.Text;
            Cliente cliente = ClienteCollection.BuscarClientePorRut(rut);

            cliente.Nombres = txtNombres.Text;
            cliente.Apellidos = txtApellidos.Text;
            cliente.FechaNacimiento = dpFechaNacimiento.SelectedDate.Value;
            cliente.EstadoCivilId = int.Parse(cboEstadoCivil.SelectedValue.ToString());

            if (rbtHombre.IsChecked == true)
            {
                cliente.Sex = 0;
            }
            else
            {
                cliente.Sex = 1;
            }

            if (ClienteCollection.ModificarCliente(cliente))
            {
                MessageBox.Show("Modificado correctamente");
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error al intentar modificar");
            }

            CargarGrilla();
        }

        private void btnEstadisticas_Click(object sender, RoutedEventArgs e)
        {
            Estadisticas ventanaEstadisticas = new Estadisticas();
            //le pasamos el listado a la ventana estadisticas
            ventanaEstadisticas.ClienteCollection = this.ClienteCollection;
            ventanaEstadisticas.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //este metodo se ejecuta cuando la ventana
            //se esta cerrando
            ventanaPrincipal = null;
        }

        public void RecibirCliente(Cliente cliente)
        {
            //a este metodo llegará el cliente enviado desde
            //el listado

            txtRut.Text = cliente.Rut;
            txtNombres.Text = cliente.Nombres;
            txtApellidos.Text = cliente.Apellidos;
            dpFechaNacimiento.SelectedDate = cliente.FechaNacimiento;
            cboEstadoCivil.SelectedIndex = (int)cliente.EstadoCivil;

            if (cliente.Sexo == Sexo.Hombre)
            {
                rbtHombre.IsChecked = true;
            }
            else
            {
                rbtMujer.IsChecked = true;
            }

        }

        private void btnListado_Click(object sender, RoutedEventArgs e)
        {
            ListadoClientes.getInstance().Show();
            ListadoClientes.getInstance().ClienteCollection = this._clienteCollection;

        }
    }
}
