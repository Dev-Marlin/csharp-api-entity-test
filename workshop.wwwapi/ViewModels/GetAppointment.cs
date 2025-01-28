using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.ViewModels
{
    public class GetAppointment
    {
        public DateTime Booking { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }

        public string PatientName { get; set; }
        public string DoctorName { get; set; }
    }
}
