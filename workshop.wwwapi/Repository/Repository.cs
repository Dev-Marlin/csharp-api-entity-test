using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DatabaseContext _databaseContext;
        public Repository(DatabaseContext db)
        {
            _databaseContext = db;
        }
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _databaseContext.Patients.Include(p => p.Appointments).ThenInclude(d => d.Doctor).ToListAsync();
        }

        public async Task<Patient> GetPatientById(int id)
        {
            return await _databaseContext.Patients.Include(p => p.Appointments).ThenInclude(d => d.Doctor).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Patient> AddPatient(Patient p)
        {
            _databaseContext.Patients.Add(p);
            await _databaseContext.SaveChangesAsync();

            return p;
        }


        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.Include(d => d.Appointments).ThenInclude(p => p.Patient).ToListAsync();
        }
        public async Task<Doctor> GetDoctorById(int id)
        {
            return await _databaseContext.Doctors.Include(d => d.Appointments).ThenInclude(p => p.Patient).FirstAsync(x => x.Id == id);
        }

        public async Task<Doctor> AddDoctor(Doctor d)
        {
            _databaseContext.Doctors.Add(d);
            await _databaseContext.SaveChangesAsync();

            return d;
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments.Include(d => d.Doctor).Include(p => p.Patient).ToListAsync();
        }

        public async Task<Appointment> GetAppointmentById(int id)
        {
            return await _databaseContext.Appointments.FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.DoctorId==id).ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.PatientId == id).ToListAsync();
        }
        public async Task<Appointment> AddAppointment(Appointment a)
        {
            _databaseContext.Appointments.Add(a);

            var tempDoctor = _databaseContext.Doctors.Update(a.Doctor);
            tempDoctor.Entity.Appointments.ToList().Add(a);

            var tempPatient = _databaseContext.Patients.Update(a.Patient);
            tempPatient.Entity.Appointments.ToList().Add(a);

            await _databaseContext.SaveChangesAsync();

            return a;
        }
    }
}
