using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIObesidad.Modelo
{
    public class medicos
    {
        [Key]
        public int id {  get; set; }
        public string nombre { get; set; }
        public string pass {  get; set; }
    }
}
