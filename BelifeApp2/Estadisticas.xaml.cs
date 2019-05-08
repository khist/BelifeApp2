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
    /// Lógica de interacción para Estadisticas.xaml
    /// </summary>
    public partial class Estadisticas : Window
    {

        private ClienteCollection _clienteCollection;

        public Estadisticas()
        {

            InitializeComponent();

            cboEstadoCivil.ItemsSource = Enum.GetValues(typeof(EstadoCivil));
            cboEstadoCivil.SelectedIndex = 0;
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

        private void btnMostrar_Click(object sender, RoutedEventArgs e)
        {
            
            txtCantidad.Text = this.ClienteCollection.cantidadClientes().ToString();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            txtCantidad.Text = this.ClienteCollection.cantidadClientes().ToString();
            txtFechaMinima.Text = this.ClienteCollection.fechaMinima().ToShortDateString();
            //obtenemos el elemento seleccionado en el combobox
            EstadoCivil estadoCivil = (EstadoCivil)cboEstadoCivil.SelectedIndex;
            txtCantidadEstadoCivil.Text 
                = this.ClienteCollection
                .cantidadClientesPorEstadoCivil(estadoCivil)
                .ToString();

            
        }
    }
}
