using System;
using DocotAppointmentSystem.Enums;
using DocotAppointmentSystem.Models;

namespace DocotAppointmentSystem.Services;

public class AuthentificationManager
{
    static List<Patient> patients = AppointmentManager.Patients;
    // static List<Doctor> doctors = AppointmentManager.Doctors;
    // static List<Appointment> appointments = AppointmentManager.Appointments;

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

        return new Tuple<string, string, int, Gender>(name, password, age, gender);

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
        do
        {
            DisplayMenu();
            char choice = char.Parse(Console.ReadLine()!);
            switch (choice)
            {
                case 'a':
                    AppointmentManager.BookAppointment(patient);
                    break;
                case 'b':
                    AppointmentManager.ViewAppointments(patient);
                    break;
                case 'c':
                    EditProfile(patient);
                    break;
                case 'd':
                    return;
                    
                default:
                    break;
            }
        } while (true);
    }

    private static void EditProfile(Patient patient)
    {
        var patientData = GetPatientData();

        patient.Name = patientData.Item1;
        patient.Password = patientData.Item2;
        patient.Age = patientData.Item3;
        patient.Gender = patientData.Item4;
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
