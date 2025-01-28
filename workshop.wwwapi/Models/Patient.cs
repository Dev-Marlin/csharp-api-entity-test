using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    [Table("patients")]
    public class Patient
    {
        [Key]
        [Column("patientid")]
        public int Id { get; set; }

        [Column("fullname")]
        public string FullName { get; set; }

        [Column("appointments")]
        //public IEnumerable<Appointment> Appointments { get; set; } = [];
        public ICollection<Appointment> Appointments { get; set; } = [];
    }
}
