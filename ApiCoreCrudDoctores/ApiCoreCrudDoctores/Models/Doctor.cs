using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCoreCrudDoctores.Models
{
    [Table("DOCTOR")]
    public class Doctor
    {
        [Key]
        [Column("DOCTOR_NO")]
        public int DoctorNo { get; set; }

        [Column("HOSPITAL_COD")]
        public int HospiCod { get; set; }

        [Column("APELLIDO")]
        public string Apellido { get; set; }

        [Column("ESPECIALIDAD")]
        public string Especialidad { get; set; }

        [Column("SALARIO")]
        public int Salario { get; set; }

    }
}
