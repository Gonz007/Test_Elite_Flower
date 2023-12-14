using System.ComponentModel.DataAnnotations;

namespace TestEliteFlower.Domain.Entities
{
    public class Articulo
    {
        [Key]
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public int Fabricante { get; set; }
        public string DatosImagen { get; set; }
    }
}
