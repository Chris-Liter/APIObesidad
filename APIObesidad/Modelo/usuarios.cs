using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIObesidad.Modelo
{
    //[Table("usuario")]
    public class usuarios
    {
        [Key]
        public int id {  get; set; }
        public string? cedula {  get; set; }
        public string? nombres {  get; set; }
        public string? apellidos {  get; set; }
        public string? telefono {  get; set; }
        public string? correo {  get; set; }

        //Informacion para entrenamiento de la IA   

        public int? edad {  get; set; }
        public double? altura {  get; set; }
        public double? peso {  get; set; }
        public bool? historialfamiliar {  get; set; }
        public string? entrecomidas {  get; set; }
        public bool? comidascaloricas {  get; set; }
    }
}
