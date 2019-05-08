using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Belife.DALC;
namespace BelifeLibrary
{
    public class ClienteCollection
    {

        //el objeto entities es el objeto de conexion a la BBDD
        private belifeEntities db = new belifeEntities();

        private List<Cliente> _clientes = new List<Cliente>();

        public List<Cliente> Clientes
        {
            get
            {
                return _clientes;
            }

            set
            {
                _clientes = value;
            }
        }

        public bool AgregarCliente(Cliente cliente)
        {
            if(BuscarClientePorRut(cliente.Rut)!=null)
            {
                return false;
            }

            this.Clientes.Add(cliente);
            return true;
        }

        public Cliente BuscarClientePorRut(string rut)
        {
            try
            {
                return (from c in this.db.Cliente
                        where c.Rut == rut
                        select new Cliente() {
                            Rut = c.Rut,
                            Nombres = c.Nombres,
                            Apellidos = c.Apellidos,
                            FechaNacimiento = c.FechaNacimiento,
                            Sex = c.Sexo,
                            EstadoCivilId = c.EstadoCivilId
                        }).First();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool EliminarCliente(string rut)
        {
            Cliente cliente = BuscarClientePorRut(rut);
            if(cliente==null)
            {
                return false;
            }

            this.Clientes.Remove(cliente);
            return true;
        }

        public int cantidadClientes()
        {
            int cantidad = (from c in this.Clientes select c).Count();
            return cantidad;
        }

        public DateTime fechaMinima()
        {
            
            //this.Clientes.Count
            DateTime fechaMinima 
                = (from c in this.Clientes select c.FechaNacimiento).Min();
            return fechaMinima;
        }

        //obtendremos la cantidad de personas nacidas antes del 01-01-2000
        public int cantidadPreMilenio()
        {
            int cantidad =
                (from c in this.Clientes
                 where c.FechaNacimiento < DateTime.Parse("01-01-2000")
                 select c).Count();

            return cantidad;
        }

        //rescataremos la cantidad de personas segun su estado civil
        public int cantidadClientesPorEstadoCivil(EstadoCivil estadoCivil)
        {
            int cantidad = (from c in this.Clientes
                            where c.EstadoCivil == estadoCivil
                            select c).Count();
            return cantidad;
        }

        public List<Cliente> clientePorRut(string rut)
        {
            return (from c in this.Clientes
                    where c.Rut == rut
                    select c).ToList();
        }

        public List<Cliente> clientesPorEstadoCivil(EstadoCivil civil)
        {
            return (from c in this.Clientes
                    where c.EstadoCivil == civil
                    select c).ToList();
        }

        public List<Cliente> ReadAll()
        {
            return (from c in db.Cliente select new Cliente() {
                Rut = c.Rut,
                Nombres = c.Nombres,
                Apellidos = c.Apellidos,
                Sex  = c.Sexo,
                FechaNacimiento = c.FechaNacimiento,
                EstadosCivil = new EstadosCivil()
                {
                    Id = c.EstadoCivil.Id,
                    Descripcion = c.EstadoCivil.Descripcion
                }
            }).ToList();
        } 

        public bool InsertarCliente(Cliente cliente)
        {
            try
            {
                //creamos un cliente de DALC, ya que el tiene
                //acceso a la BBDD
                Belife.DALC.Cliente c = new Belife.DALC.Cliente();
                c.Rut = cliente.Rut;
                c.Nombres = cliente.Nombres;
                c.Apellidos = cliente.Apellidos;
                c.FechaNacimiento = cliente.FechaNacimiento;

                c.Sexo = cliente.Sex;
                c.EstadoCivilId = cliente.EstadoCivilId;
                //le decimos al entity framework que guarde
                //el cliente
                db.Cliente.Add(c);
                //db.Cliente.Remove(c);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool ModificarCliente(Cliente cliente)
        {
            try
            {
                //para poder modificar primero debemos buscar el cliente
                Belife.DALC.Cliente c = this.db.Cliente.Find(cliente.Rut);
                c.Nombres = cliente.Nombres;
                c.Apellidos = cliente.Apellidos;
                c.FechaNacimiento = cliente.FechaNacimiento;
                c.EstadoCivilId = cliente.EstadoCivilId;
                c.Sexo = cliente.Sex;

                //para actualizar un registro hay que cambiar su estado
                this.db.Entry(c).State = System.Data.EntityState.Modified;
                this.db.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool EliminarClientes(string rut)
        {
            try
            {
                //para eliminar primero debemos buscar
                Belife.DALC.Cliente c = this.db.Cliente.Find(rut);

                this.db.Cliente.Remove(c);
                this.db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}
