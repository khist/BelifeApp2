using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelifeLibrary
{
    public class Cliente
    {
        private string _rut; 
        private string _nombres;
        private string _apellidos;
        private DateTime _fechaNacimiento;
        private Sexo _sexo;

        private EstadoCivil _estadoCivil;


        private int _sex;
        private int _estadoCivilId;
        private EstadosCivil _estadosCivil;

        public Cliente()
        {
           
        }

        

        public Cliente(string rut,
            string nombres, 
            string apellidos,
            DateTime fechaNacimiento,
            Sexo sexo,
            EstadoCivil estadoCivil)
        {
            //se asignan los valores utilizando la propiedad
            this.Rut = rut;
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.FechaNacimiento = fechaNacimiento;
            this.Sexo = sexo;
            this.EstadoCivil = estadoCivil;

        }

        public string Rut
        {
            get
            {
                return _rut;
            }

            set
            {
                _rut = value;
            }
        }

        public string Nombres
        {
            get
            {
                return _nombres;
            }

            set
            {
                _nombres = value;
            }
        }

        public string Apellidos
        {
            get
            {
                return _apellidos;
            }

            set
            {
                _apellidos = value;
            }
        }

        public DateTime FechaNacimiento
        {
            get
            {
                return _fechaNacimiento;
            }

            set
            {
                _fechaNacimiento = value;
            }
        }

        public Sexo Sexo
        {
            get
            {
                return _sexo;
            }

            set
            {
                _sexo = value;
            }
        }

        public EstadoCivil EstadoCivil
        {
            get
            {
                return _estadoCivil;
            }

            set
            {
                _estadoCivil = value;
            }
        }

        public int Sex
        {
            get
            {
                return _sex;
            }

            set
            {
                _sex = value;
            }
        }



        public int EstadoCivilId
        {
            get
            {
                return _estadoCivilId;
            }

            set
            {
                _estadoCivilId = value;
            }
        }

        public EstadosCivil EstadosCivil
        {
            get
            {
                return _estadosCivil;
            }

            set
            {
                _estadosCivil = value;
            }
        }

        public string NombreSexo
        {
            get
            {
                if(Sex == 0)
                {
                    return "Hombre";
                }

                return "Mujer";
            }
        }
    }
}
