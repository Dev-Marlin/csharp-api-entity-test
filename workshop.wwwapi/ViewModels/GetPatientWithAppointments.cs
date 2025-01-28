using workshop.wwwapi.Models;

namespace workshop.wwwapi.ViewModels
{
    public class GetPatientWithAppointments
    {
        public string FullName { get; set; }
        public IEnumerable<GetPatientAppointments> Appointments { get; set; } = [];
    }
}
