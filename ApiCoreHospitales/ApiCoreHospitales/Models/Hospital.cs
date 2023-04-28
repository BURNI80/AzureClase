using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCoreHospitales.Models
{
    [Table("HOSPITAL")]
    public class Hospital
    {
        [Key]
        [Column("HOSPITAL_COD")]
        public int Id { get; set; }

        [Column("NOMBRE")]
        public string Nombre { get; set; }

        [Column("DIRECCION")]
        public string Direccion { get; set; }

        [Column("TELEFONO")]
        public string Telefono { get; set; }

        [Column("NUM_CAMA")]
        public int NumCamas { get; set; }

    }
}
