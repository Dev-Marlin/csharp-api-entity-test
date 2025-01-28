using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly

    [Table("appointment")]
    public class Appointment
    {

        [Column("appointmentid")]
        public int Id { get; set; }

        [Column("bookingdate")]
        public DateTime Booking { get; set; }

        [Column("appointeddoctorid")]
        [ForeignKey("DoctorId")]
        public int DoctorId { get; set; }

        [Column("patientid")]
        [ForeignKey("PatientId")]
        public int PatientId { get; set; }

        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }

    }
}
