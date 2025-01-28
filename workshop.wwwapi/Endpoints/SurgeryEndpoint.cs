using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using workshop.wwwapi.ViewModels;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patients/{id}", GetPatientById);
            surgeryGroup.MapPost("/patients/add", AddPatient);

            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctorById);
            surgeryGroup.MapPost("/doctors/add", AddDoctor);

            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointments/{id}", GetAppointmentById);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapPost("/appointments/add", AddAppointment);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var patients = await repository.GetPatients();

            List<GetPatientWithAppointments> patientList = new List<GetPatientWithAppointments>();

            foreach (var patient in patients)
            {
                List<GetPatientAppointments> list = new List<GetPatientAppointments>();

                foreach (Appointment a in patient.Appointments)
                {
                    GetPatientAppointments temp = new GetPatientAppointments()
                    {
                        Booking = a.Booking,
                        DoctorName = a.Doctor.FullName,
                        DoctorId = a.DoctorId
                    };

                    list.Add(temp);
                }

                GetPatientWithAppointments gp = new GetPatientWithAppointments()
                {
                    FullName = patient.FullName,
                    Appointments = list
                };

                patientList.Add(gp);
            }
            return TypedResults.Ok(patientList);
        }

        public static async Task<IResult> GetPatientById(IRepository repository, int id)
        {
            var patient = await repository.GetPatientById(id);
            List<GetPatientAppointments> list = new List<GetPatientAppointments>();

            foreach (Appointment a in patient.Appointments)
            {
                GetPatientAppointments temp = new GetPatientAppointments()
                {
                    Booking = a.Booking,
                    DoctorName = a.Doctor.FullName,
                    DoctorId = a.DoctorId
                };

                list.Add(temp);
            }

            GetPatientWithAppointments gp = new GetPatientWithAppointments()
            {
                FullName = patient.FullName,
                Appointments = list
            };

            return TypedResults.Created("", gp);
        }

        public static async Task<IResult> AddPatient(IRepository repository, Patient p)
        {
            var patient =  await repository.AddPatient(p);


            List<GetPatientAppointments> list = new List<GetPatientAppointments>();

            foreach (Appointment a in p.Appointments)
            {
                GetPatientAppointments temp = new GetPatientAppointments()
                {
                    Booking = a.Booking,
                    DoctorName = a.Doctor.FullName,
                    DoctorId = a.DoctorId
                };

                list.Add(temp);
            }

            GetPatientWithAppointments gp = new GetPatientWithAppointments()
            {
                FullName = patient.FullName,
                Appointments = list
            };

            return TypedResults.Created("", gp);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            IEnumerable<Doctor> docs = await repository.GetDoctors();
            List<GetDoctorWithAppointments> getDoctors = new List<GetDoctorWithAppointments>();

            foreach (Doctor d in docs)
            {
                List<GetDoctorAppointments> list = new List<GetDoctorAppointments>();

                foreach (Appointment a in d.Appointments)
                {
                    GetDoctorAppointments temp = new GetDoctorAppointments()
                    {
                        Booking = a.Booking,
                        PatientName = a.Patient.FullName,
                        PatientId = a.PatientId
                    };

                    list.Add(temp);
                }

                GetDoctorWithAppointments gd = new GetDoctorWithAppointments()
                {
                    Id = d.Id,
                    FullName = d.FullName,
                    Appointments = list
                };

                getDoctors.Add(gd);
            }

            return TypedResults.Ok(getDoctors);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctorById(IRepository repository, int id)
        {
            Doctor d = await repository.GetDoctorById(id);
            List<GetDoctorAppointments> list = new List<GetDoctorAppointments>();

            foreach (Appointment a in d.Appointments)
            {
                GetDoctorAppointments temp = new GetDoctorAppointments()
                {
                    Booking = a.Booking,
                    PatientName = a.Patient.FullName,
                    PatientId = a.PatientId
                };

                list.Add(temp);
            }

            GetDoctorWithAppointments gd = new GetDoctorWithAppointments()
            {
                Id = d.Id,
                FullName = d.FullName,
                Appointments = list
            };

            return TypedResults.Ok(gd);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddDoctor(IRepository repository, Doctor d)
        {
            await repository.AddDoctor(d);

            List<GetDoctorAppointments> list = new List<GetDoctorAppointments>();

            foreach(Appointment a in d.Appointments)
            {
                GetDoctorAppointments temp = new GetDoctorAppointments()
                {
                    Booking = a.Booking,
                    PatientName = a.Patient.FullName,
                    PatientId = a.PatientId
                };

                list.Add(temp);
            }

            GetDoctorWithAppointments gd = new GetDoctorWithAppointments()
            {
                Id = d.Id,
                FullName= d.FullName,
                Appointments = list
            };


            return TypedResults.Ok(gd);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            IEnumerable<Appointment> app = await repository.GetAppointments();
            List<GetAppointment> getAppointments = new List<GetAppointment>();

            foreach (Appointment appointment in app)
            {
                GetAppointment temp = new GetAppointment()
                {
                    Booking = appointment.Booking,
                    DoctorName = appointment.Doctor.FullName,
                    DoctorId = appointment.DoctorId,
                    PatientName = appointment.Patient.FullName,
                    PatientId = appointment.Patient.Id
                };

                getAppointments.Add(temp);
            }



            return TypedResults.Ok(getAppointments);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentById(IRepository repository, int id)
        {
            Appointment appointment = await repository.GetAppointmentById(id);

            GetAppointment temp = new GetAppointment()
            {
                Booking = appointment.Booking,
                DoctorName = appointment.Doctor.FullName,
                DoctorId = appointment.DoctorId,
                PatientName = appointment.Patient.FullName,
                PatientId = appointment.Patient.Id
            };

            return TypedResults.Ok(temp);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            IEnumerable<Appointment> app = await repository.GetAppointmentsByDoctor(id);
            List<GetAppointment> getAppointments = new List<GetAppointment>();

            foreach (Appointment appointment in app)
            {
                GetAppointment temp = new GetAppointment()
                {
                    Booking = appointment.Booking,
                    DoctorName = appointment.Doctor.FullName,
                    DoctorId = appointment.DoctorId,
                    PatientName = appointment.Patient.FullName,
                    PatientId = appointment.Patient.Id
                };

                getAppointments.Add(temp);
            }

            return TypedResults.Ok(getAppointments);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            IEnumerable<Appointment> app = await repository.GetAppointmentsByPatient(id);
            List<GetAppointment> getAppointments = new List<GetAppointment>();

            foreach (Appointment appointment in app)
            {
                GetAppointment temp = new GetAppointment()
                {
                    Booking = appointment.Booking,
                    DoctorName = appointment.Doctor.FullName,
                    DoctorId = appointment.DoctorId,
                    PatientName = appointment.Patient.FullName,
                    PatientId = appointment.Patient.Id
                };

                getAppointments.Add(temp);
            }

            return TypedResults.Ok(getAppointments);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddAppointment(IRepository repository, Appointment appointment)
        {
            await repository.AddAppointment(appointment);

            GetAppointment temp = new GetAppointment()
            {
                Booking = appointment.Booking,
                DoctorName = appointment.Doctor.FullName,
                DoctorId = appointment.DoctorId,
                PatientName = appointment.Patient.FullName,
                PatientId = appointment.Patient.Id
            };

            return TypedResults.Ok(temp);
        }
    }
}
