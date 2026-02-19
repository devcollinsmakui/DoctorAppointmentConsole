using System;
using System.Security.Cryptography.X509Certificates;
using DocotAppointmentSystem.Enums;
using DocotAppointmentSystem.Models;

namespace DocotAppointmentSystem.Services;

public delegate void EventHandler(string a);
public class AppointmentManager
{
    public static List<Doctor> doctors = new()
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
    public static List<Appointment> appointments = new()
    {
        new Appointment { PatientID = 1, DoctorID = 2, Date = new DateTime(2012/3/8), Problem = "Heart problem"},
        new Appointment { PatientID = 1, DoctorID = 5, Date = new DateTime(2012/3/8), Problem = "Spinal cord injury"},
        new Appointment { PatientID = 2, DoctorID = 2, Date = new DateTime(2012/3/8), Problem = "Heart attack"},
    };

    public event EventHandler BookAppointmentEvent;

    public static void OnBookAppointment(string a)
    {
        Console.WriteLine(a);
    }
    public static void BookAppointment(Patient patient)
    {
        string selectedDepartent = SelectDepartment();
        var doctor = doctors.FirstOrDefault(d => d.Department == selectedDepartent);
        string userchoice = "";

        if (doctor != null && appointments.Where(a => a.DoctorID == doctor.DoctorID && a.Date == DateTime.Now).ToList().Count() < 2)
        {
            string problem = GetPatientProblem();
            var appointment = new Appointment { PatientID = patient.PatientID, DoctorID = doctor.DoctorID, Date = DateTime.Now, Problem = problem };

            do
            {
                Console.WriteLine($"Appointment is confirmed for the date {DateTime.Now.ToShortDateString()}. To book press \"Y\", to cancle press \"N\"");
                userchoice = Console.ReadLine()!;
                if (userchoice == "Y")
                {
                    appointments.Add(appointment);
                    OnBookAppointment("Appoinment added!");
                }
                else if (userchoice == "N")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid choice!");
                }
            } while (userchoice != "Y" && userchoice != "N");
        }
        else
        {
            Console.WriteLine("Not available");
        }
    }
    public static string GetPatientProblem()
    {
        Console.WriteLine("Please specify the health Issue: ");
        return Console.ReadLine()!.Trim();
    }
    public static string SelectDepartment()
    {
        Console.WriteLine("\nSelect the department from the below List:\n");
        Console.WriteLine("1.Anaesthesiology, 2.Cardiology, 3.Diabetology, 4.Neonatology, 5.Nephrology");
        char selected = char.Parse(Console.ReadLine()!);
        switch (selected)
        {
            case '1':
                return "Anaesthesiology";
            case '2':
                return "Cardiology";
            case '3':
                return "Diabetology";
            case '4':
                return "Neonatology";
            case '5':
                return "Nephrology";
            default:
                return "";
        }
    }
    public static void ViewAppointments(Patient patient)
    {
        var patientAppointments = appointments.Where(x => x.PatientID == patient.PatientID).ToList();
        Console.WriteLine(new String('_', 60));
        Console.WriteLine($"{"AppointmentID",-15}, {"PatientID",-10}, {"DoctorID",-10}, {"Problem",-15}");
        Console.WriteLine(new String('_', 60));
        patientAppointments.ForEach(x => Console.WriteLine($"{x.AppointmentID,-15}, {x.PatientID,-10}, {x.DoctorID,-10}, {x.Problem,-15}"));
        Console.WriteLine(new String('_', 60));
    }

}