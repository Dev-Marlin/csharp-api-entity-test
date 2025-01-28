using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        public Task<IEnumerable<Patient>> GetPatients();
        public Task<Patient> GetPatientById(int id);
        public Task<Patient> AddPatient(Patient p);

        public Task<IEnumerable<Doctor>> GetDoctors();
        public Task<Doctor> GetDoctorById(int id);
        public Task<Doctor> AddDoctor(Doctor d);


        public Task<IEnumerable<Appointment>> GetAppointments();
        public Task<Appointment> GetAppointmentById(int id);
        public Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        public Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id);
        public Task<Appointment> AddAppointment(Appointment a);

    }
}
