//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Belife.DALC
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cliente
    {
        public string Rut { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public int Sexo { get; set; }
        public int EstadoCivilId { get; set; }
    
        public virtual EstadoCivil EstadoCivil { get; set; }
    }
}
