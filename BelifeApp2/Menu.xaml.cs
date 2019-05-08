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
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu
    {

        private ClienteCollection _clienteCollection
            = new ClienteCollection();

        public static Menu ventanaMenu;

        public static Menu getInstance()
        {
            if(ventanaMenu == null)
            {
                ventanaMenu = new Menu();
            }

            return ventanaMenu;
        }


        public Menu()
        {
            InitializeComponent();
            //la primera vez que se inicie esta ventana
            //la llamara el sistema y la ventana completa
            //se guardara en la variale ventanaMenu
            ventanaMenu = this;
        }

        private void Tile_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.getInstance().Show();
            MainWindow.getInstance().ClienteCollection = this._clienteCollection;
        }

        private void Tile_Click_1(object sender, RoutedEventArgs e)
        {
            ListadoClientes.getInstance().Show();
            ListadoClientes.getInstance().ClienteCollection = this._clienteCollection;
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
