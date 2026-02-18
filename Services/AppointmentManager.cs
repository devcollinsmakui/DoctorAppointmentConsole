using System;
using System.Security.Cryptography.X509Certificates;
using DocotAppointmentSystem.Enums;
using DocotAppointmentSystem.Models;

namespace DocotAppointmentSystem.Services;

public class AppointmentManager
{
    public static List<Doctor> Doctors = new()
    {
        new Doctor{ DoctorID = 1,Name ="Nancy", Department ="Anaesthesiology"},
        new Doctor{ DoctorID = 2,Name ="Andrew", Department ="Cardiology"},
        new Doctor{ DoctorID = 3,Name ="Janet", Department ="Diabetology"},
        new Doctor{ DoctorID = 4,Name ="Margaret", Department ="Neonatology"},
        new Doctor{ DoctorID = 5,Name ="Steven", Department ="Nephrology"},
    };
    public static List<Patient> Patients = new()
    {
        new Patient{ Password = "welcome", Name = "Robert", Age = 40, Gender = Gender.Male},
        new Patient{ Password = "welcome", Name = "Laura", Age = 36, Gender = Gender.Female},
        new Patient{ Password = "welcome", Name = "Anne", Age = 42, Gender = Gender.Female},
    };
    public static List<Appointment> Appointments = new()
    {
        new Appointment { PatientID = 1, DoctorID = 2, Date = new DateTime(2012/3/8), Problem = "Heart problem"},
        new Appointment { PatientID = 1, DoctorID = 5, Date = new DateTime(2012/3/8), Problem = "Spinal cord injury"},
        new Appointment { PatientID = 2, DoctorID = 2, Date = new DateTime(2012/3/8), Problem = "Heart attack"},
    };

    public void BookAppointment(){}
    public void ViewAppointments(){}
    public void EditPatientProfile(int PatientID){}

}