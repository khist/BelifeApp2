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
using BelifeLibrary;

namespace BelifeApp2
{
    /// <summary>
    /// Lógica de interacción para ListadoClientes.xaml
    /// </summary>
    public partial class ListadoClientes : Window
    {
        private ClienteCollection _clienteCollection
            = new ClienteCollection();

        public static ListadoClientes ventanaListado;

        public static ListadoClientes getInstance()
        {
            if(ventanaListado == null)
            {
                ventanaListado = new ListadoClientes();
            }
            return ventanaListado;
        }

        public ListadoClientes()
        {
            InitializeComponent();
            cboEstadoCivil.ItemsSource = Enum.GetValues(typeof(EstadoCivil));
            cboEstadoCivil.SelectedIndex = 0;

            //llamaremos al metodo ReadAll de la coleccion para listar 
            //todos los registros de la BBDD
            dgClientes.ItemsSource = null;
            dgClientes.ItemsSource = ClienteCollection.ReadAll();
                
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

        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            dgClientes.ItemsSource = null;
            dgClientes.ItemsSource = this.ClienteCollection.Clientes;
        }

        private void btnFiltrarRut_Click(object sender, RoutedEventArgs e)
        {
            string rut = txtRut.Text;

            dgClientes.ItemsSource = null;
            dgClientes.ItemsSource = this.ClienteCollection.clientePorRut(rut);
        }

        private void btnFiltrarEstadoCivil_Click(object sender, RoutedEventArgs e)
        {
            EstadoCivil estadoCivil = (EstadoCivil)cboEstadoCivil.SelectedIndex;

            dgClientes.ItemsSource = null;
            dgClientes.ItemsSource = 
                this.ClienteCollection
                .clientesPorEstadoCivil(estadoCivil);
  
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ventanaListado = null;
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Menu.getInstance().Show();
            this.Close();
        }

        private void dgClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //obtendremos el cliente seleccionado en la grilla
            //por el usuario
            Cliente cliente = (Cliente)dgClientes.SelectedItem;

            if(cliente != null)
            {
                String rut = "1111111-1";
                //expresiones regulares
                //si existe el cliente
                //debemos mandarlo a la ventana de gestion (MainWindow)
                MainWindow.getInstance().RecibirCliente(cliente);
            }
        }
    }
}
