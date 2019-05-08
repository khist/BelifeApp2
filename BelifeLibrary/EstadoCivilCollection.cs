using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Belife.DALC;
namespace BelifeLibrary
{
    public class EstadoCivilCollection
    {

        private belifeEntities db = new belifeEntities();

        public List<EstadosCivil> ReadAll()
        {
            //en el select transformamos 
            //la clase EstadoCivil de DALC
            //en una clase EstadosCivil de negocio (la que nosotros creamos)
            return (from e in db.EstadoCivil
                    select new EstadosCivil() {
                        Id = e.Id,
						Descripcion = e.Descripcion
                    }).ToList();
        }

    }
}
