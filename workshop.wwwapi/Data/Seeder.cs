using workshop.wwwapi.Migrations;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class Seeder
    {
        private List<string> firstnames = new List<string>();
        private List<string> lastnames = new List<string>();
        private List<DateTime> dateTimes = new List<DateTime>();

        public Seeder()
        {
            InitializeFirstNames();
            InitializeLastNames();
            InitializeDates();
            InitializePatients();
            InitializeDoctors();
            InitializeAppointments();
        }

        private void InitializeAppointments()
        {
            //Random randomDoctor = new Random();
            //Random randomPatient = new Random();
            Random randomDate = new Random();

            /*
            for (int i = 1; i < 101; i++)
            {
                int rd = randomDoctor.Next(10);
                int rp = randomPatient.Next(10);

                Appointment tempApp = new Appointment()
                {
                    //Id = i,
                    Booking = dateTimes[randomDate.Next(10)],
                    DoctorId = rd,
                    PatientId = rp
                };

                Doctors[rd].Appointments.ToList().Add(tempApp);
                Patients[rp].Appointments.ToList().Add(tempApp);

                Appointments.Add(tempApp);
            }*/
            int counter = 1;
            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    Appointment tempApp = new Appointment()
                    {
                        Booking = DateTime.UtcNow,//dateTimes[randomDate.Next(10)],
                        DoctorId = i,
                        PatientId = j,
                        Id = counter
                        //Doctor = Doctors[i - 1],
                        //Patient = Patients[j - 1]
                    };
                    counter++;

                    Doctors[i-1].Appointments.ToList().Add(tempApp);
                    Patients[j-1].Appointments.ToList().Add(tempApp);

                    Appointments.Add(tempApp);
                }
            }
        }

        private void InitializePatients()
        {
            Random randomFirstname = new Random();
            Random randomLastname = new Random();

            for (int i = 1; i < 51; i++)
            {
                Patient tempPat = new Patient()
                {
                    Id = i,
                    FullName = String.Concat(firstnames[randomFirstname.Next(10)], " " + lastnames[randomLastname.Next(10)])
                };

                Patients.Add(tempPat);               
            }
        }

        private void InitializeDoctors()
        {
            Random randomFirstname = new Random();
            Random randomLastname = new Random();

            for(int i = 1; i < 11; i++)
            {
                Doctor tempDoc = new Doctor()
                {
                    Id = i,
                    FullName = String.Concat(firstnames[randomFirstname.Next(10)], " "+lastnames[randomLastname.Next(10)])
                };

                Doctors.Add(tempDoc);
            }
        }

        private void InitializeFirstNames()
        {
            firstnames.Add("Sofia");
            firstnames.Add("Adrian");
            firstnames.Add("Johannes");
            firstnames.Add("Emma");
            firstnames.Add("Nigel");
            firstnames.Add("Erik");
            firstnames.Add("Karl");
            firstnames.Add("Anna");
            firstnames.Add("Frida");
            firstnames.Add("Bert");
        }

        private void InitializeLastNames()
        {
            lastnames.Add("Davidsson");
            lastnames.Add("Thompson");
            lastnames.Add("White");
            lastnames.Add("Sanchez");
            lastnames.Add("Lewis");
            lastnames.Add("Robinson");
            lastnames.Add("Scott");
            lastnames.Add("Young");
            lastnames.Add("Hill");
            lastnames.Add("Flores");
        }

        private void InitializeDates()
        {
            dateTimes.Add(new DateTime(2024,5,1));
            dateTimes.Add(new DateTime(2025,11,27));
            dateTimes.Add(new DateTime(2025,1,2));
            dateTimes.Add(new DateTime(2024,3,14));
            dateTimes.Add(new DateTime(2025,11,12));
            dateTimes.Add(new DateTime(2024,3,8));
            dateTimes.Add(new DateTime(2024,7,29));
            dateTimes.Add(new DateTime(2025,7,19));
            dateTimes.Add(new DateTime(2024,10,5));
            dateTimes.Add(new DateTime(2024,12,3));
        }

        public List<Patient> Patients { get; set; } = [];
        public List<Doctor> Doctors { get; set; } = [];
        public List<Appointment> Appointments { get; set; } = [];
    }
}
