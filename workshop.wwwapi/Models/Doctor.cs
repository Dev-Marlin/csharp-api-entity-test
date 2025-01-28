using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    [Table("doctors")]
    public class Doctor
    {
        [Key]
        [Column("doctorid")]
        public int Id { get; set; }

        [Column("fullname")]
        public string FullName { get; set; }

        [Column("appointments")]
        //public IEnumerable<Appointment> Appointments { get; set; } = [];
        public ICollection<Appointment> Appointments { get; set; } = [];
    }
}
