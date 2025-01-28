using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.ViewModels
{
    public class GetDoctorWithAppointments
    {
        public string FullName { get; set; }

        public int Id { get; set; }
        public IEnumerable<GetDoctorAppointments> Appointments { get; set; } = [];
    }
}
