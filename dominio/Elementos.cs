using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Elementos
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }

        /*Sobre exribir tostring para visualizar en comboBox y visualizar en planilla*/

        public override string ToString()
        {
            return Descripcion;
        }

    }
}
