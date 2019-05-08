using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BelifeLibrary;
namespace BelifeWEB
{
    public partial class ClienteForm : System.Web.UI.Page
    {
        private ClienteCollection _clienteCollection
            = new ClienteCollection();

        protected void Page_Load(object sender, EventArgs e)
        {
            //rescateremos la coleccion desde la sesion si es que existe
            if(Session["coleccion"] != null)
            {
                this._clienteCollection = (ClienteCollection)Session["coleccion"];
            }

            //isPostBack
            //si es la primera vez que se carga la pagina isPostBack es false
            //si se enviaron datos (pincharon el boton) isPostBack es true
            if(!IsPostBack)
            {
                //si es la primera vez que la pagina se carga
                //se cargará el dropdown
                ddlEstadoCivil.DataSource = Enum.GetValues(typeof(EstadoCivil));
                ddlEstadoCivil.SelectedIndex = 0;
                //se refresca el dropdownlist con
                //el metodo databind
                ddlEstadoCivil.DataBind();
            }
            
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Rut = txtRut.Text;
            cliente.Nombres = txtNombres.Text;
            cliente.Apellidos = txtApellidos.Text;
            cliente.FechaNacimiento = clFechaNacimiento.SelectedDate;
            if (rbtHombre.Checked)
            {
                cliente.Sexo = Sexo.Hombre;
            }
            else
            {
                cliente.Sexo = Sexo.Mujer;
            }

            cliente.EstadoCivil = (EstadoCivil)ddlEstadoCivil.SelectedIndex;

            if (this._clienteCollection.AgregarCliente(cliente))
            {
                lblMensaje.Text = "Guardado correctamente";
            }
            else
            {
                lblMensaje.Text = "El RUT ya existe";
            }

            CargarGrilla();
            //guardaremos la coleccion en la sesion
            //de esta manera no la perderemos entre request
            Session["coleccion"] = this._clienteCollection;

        }

        private void CargarGrilla()
        {
            //le pasamos el listado completo al gridview para que lo muestre
            gvClientes.DataSource = this._clienteCollection.Clientes;
            //refrescamos el gridview
            gvClientes.DataBind();
        }
    }
}