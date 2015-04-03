using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirstEF6.Models
{
    public class PeliculaViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Estreno { get; set; }
        public string Duracion { get; set; }
        public int Rating { get; set; }
        public string Descripcion { get; set; }
        public string Pais { get; set; }
        public int IdGenero { get; set; }
    }
}