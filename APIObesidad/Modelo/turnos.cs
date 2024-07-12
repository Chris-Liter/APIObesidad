using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIObesidad.Modelo
{
    public class turnos
    {
        [Key]
        public int id {  get; set; }
        public string fecha { get; set; }
        public string hora {  get; set; }
        [ForeignKey("id_usuario")]
        public int id_usuario {  get; set; }
        [ForeignKey("id_medico")]
        public int id_medico {  get; set; }
        
    }
}
