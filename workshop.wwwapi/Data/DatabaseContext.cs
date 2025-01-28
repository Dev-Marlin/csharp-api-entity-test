using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class DatabaseContext : DbContext
    {
        private string _connectionString;
        
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
            this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Seeder seeder = new Seeder();
            //TODO: Appointment Key etc.. Add Here

            modelBuilder.Entity<Appointment>().HasKey(a => new { a.PatientId, a.DoctorId });

            modelBuilder.Entity<Appointment>().HasOne(d => d.Doctor).WithMany(a => a.Appointments).HasForeignKey(d => d.DoctorId);
            modelBuilder.Entity<Appointment>().HasOne(p => p.Patient).WithMany(a => a.Appointments).HasForeignKey(p => p.PatientId);

            /*
            modelBuilder.Entity<Patient>().HasMany(p => p.Appointments);
            modelBuilder.Entity<Doctor>().HasMany(d => d.Appointments);
            */


            //TODO: Seed Data Here
            modelBuilder.Entity<Patient>().HasData(seeder.Patients);
            modelBuilder.Entity<Doctor>().HasData(seeder.Doctors);
            modelBuilder.Entity<Appointment>().HasData(seeder.Appointments);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase(databaseName: "Database");
            optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message)); //see the sql EF using in the console
            
        }


        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
