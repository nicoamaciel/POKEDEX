using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace ConexionDBAPOKEDEX
{
    public class Pokemon
    {
        public int Id { get; set; }
        /*Uso de Annotations - arreglos de asentuacion*/
        [DisplayName("Número")]
        public int Numero { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public string urlImagen { get; set; }
        public Elementos Tipo { get; set; }
        public Elementos Debilidad { get; set; }

    }
}
