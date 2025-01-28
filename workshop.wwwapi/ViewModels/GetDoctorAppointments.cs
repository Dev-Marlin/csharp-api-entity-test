using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace workshop.wwwapi.ViewModels
{
    public class GetDoctorAppointments
    {
        public DateTime Booking { get; set; }
        public string PatientName { get; set; }
        public int PatientId { get; set; }
    }
}
