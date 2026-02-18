using System;
using DocotAppointmentSystem.Enums;
using DocotAppointmentSystem.Models;

namespace DocotAppointmentSystem.Services;

public class AuthentificationManager
{
    static List<Patient> patients = AppointmentManager.Patients;
    static List<Doctor> doctors = AppointmentManager.Doctors;
    static List<Appointment> appointments = AppointmentManager.Appointments;

    public static void RegisterPatient()
    {
       var patientData = GetPatientData();

        //add new user object to list
        patients.Add(new Patient { Name = patientData.Item1, Password = patientData.Item2, Age = patientData.Item3, Gender = patientData.Item4 });
        Console.WriteLine("User registered successfullly, UserID is {0}", patients.Last().PatientID);
        patients.ForEach(x => Console.WriteLine($"{x.PatientID}, {x.Password}, {x.Name}, {x.Age}, {x.Gender}"));
    }
    private static Tuple<string, string, int, Gender> GetPatientData()
    {
        Console.WriteLine("Enter name: ");
        string name = Console.ReadLine()!;

        string password = EnterPassWord();

        int age = EnterAge();

        Gender gender = EnterGender();

        return new Tuple<string, string, int, Gender>(name,password,age,gender);
        
    }

    public static void Login()
    {
        Console.WriteLine("Enter name: ");
        string userName = Console.ReadLine()!;
        Console.WriteLine("Enter Password: ");
        string password = Console.ReadLine()!;

        var patient = ValidateUserCredentials(userName, password);
        if (patient != null)
        {
            ProceedToMenu(patient);
        }
    }
    private static void ProceedToMenu(Patient patient)
    {
        DisplayMenu();
        char choice = char.Parse(Console.ReadLine()!);
        switch (choice)
        {
            case 'a':
                BookAppointment(patient);
                break;
            case 'b':
                ViewPatientAppointments(patient);
                break;
            case 'c':
                EditProfile(patient);
                break;

            default:
                break;
        }
    }

    private static void ViewPatientAppointments(Patient patient)
    {
        var patientAppointments = appointments.Where(x => x.PatientID == patient.PatientID).ToList();
        Console.WriteLine(new String('_', 60));
        Console.WriteLine($"{"AppointmentID",-15}, {"PatientID",-10}, {"DoctorID",-10}, {"Problem",-15}");
        Console.WriteLine(new String('_', 60));
        patientAppointments.ForEach(x => Console.WriteLine($"{x.AppointmentID,-15}, {x.PatientID,-10}, {x.DoctorID,-10}, {x.Problem,-15}"));
        Console.WriteLine(new String('_', 60));
    }
    private static void EditProfile(Patient patient)
    {
        var patientData = GetPatientData();

        patient.Name = patientData.Item1;
        patient.Password = patientData.Item2;
        patient.Age = patientData.Item3;
        patient.Gender = patientData.Item4;
    }

    public static void BookAppointment(Patient patient)
    {
        string selectedDepartent = SelectDepartment();
        var doctor = doctors.FirstOrDefault(d => d.Department == selectedDepartent);
        string userchoice = "";

        if (doctor != null && appointments.Select(a => a.DoctorID == doctor.DoctorID && a.Date == DateTime.Now).Count() < 2)
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

    private static void DisplayMenu()
    {
        Console.WriteLine("\nPatient Menu\n\na. Book Appointment\nb. View Appointment details\nc. Edit my profile\nd. Exit");
    }

    private static Patient? ValidateUserCredentials(string name, string password)
    {
        var patient = patients.FirstOrDefault(p => p.Name == name);
        if (patient == null || patient.Password != password)
        {
            Console.WriteLine("Sorry, your record is invalid. Please register your profile and log in again.");
            return null;
        }
        return patient;
    }
    private static Gender EnterGender()
    {
        bool correct = true;
        Gender gender = Gender.Male;
        do
        {
            Console.WriteLine("Enter Gender: 'Male/Female' ");
            try
            {
                gender = Enum.Parse<Gender>(Console.ReadLine()!);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Syntax");
                correct = false;
            }
        } while (!correct);
        return gender;
    }

    private static string EnterPassWord()
    {
        string password; string confirmPassword;
        do
        {
            Console.WriteLine("Enter password: ");
            password = Console.ReadLine()!;

            Console.WriteLine("Confirm password: ");
            confirmPassword = Console.ReadLine()!;

            if (password != confirmPassword)
            {
                Console.WriteLine("Passwords dont match!");
            }
        } while (password != confirmPassword);
        return password;
    }

    private static int EnterAge()
    {
        int age;
        bool correct;
        do
        {
            Console.WriteLine("Enter Age: ");
            correct = int.TryParse(Console.ReadLine(), out age);
        } while (!correct);
        return age;
    }
}
