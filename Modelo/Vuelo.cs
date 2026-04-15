using System.ComponentModel.DataAnnotations;

namespace ApiVuelos.Models
{
    public class Vuelo
    {
        [Key]
        public int id_vuelo { get; set; }

        [Required]
        public string origen { get; set; }

        [Required]
        public string destino { get; set; }

        public DateTime hora_salida { get; set; }

        public DateTime hora_llegada { get; set; }

        public string aerolinea { get; set; }
    }
}
