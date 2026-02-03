using DocotAppointmentSystem.Enums;
using DocotAppointmentSystem.Models;
using DocotAppointmentSystem.Services;

namespace DocotAppointmentSystem;

class Program
{
    static List<Patient> patients = AppointmentManager.Patients;
    public static void RegisterPatient()
    {
        Console.WriteLine("Enter name: ");
        string name = Console.ReadLine()!;

        string password = EnterPassWord();

        int age = EnterAge();

        Gender gender = EnterGender();

        //add new user object to list
        patients.Add(new Patient { Name = name, Password = password, Age = age, Gender = gender });
        Console.WriteLine("User registered successfullly, UserID is {0}", patients.Last().PatientID);
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
            ProceedToMenu();
        }
    }
    private static void ProceedToMenu()
    {
        DisplayMenu();
        char choice = char.Parse(Console.ReadLine()!);
        switch (choice)
        {
            case 'a':
                //
                break;
            case 'b':
                //
                break;

            default:
                break;
        }
    }

    public static void BookAppointment()
    {
        string selectedDepartent = SelectDepartment();
    }
    public static string SelectDepartment()
    {
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
    static void Main(string[] args)
    {
        Console.WriteLine("Main Menu\n 1. Login\n 2. Register\n");
        Console.WriteLine("Choose an option:");
        string choice = Console.ReadLine()!.Trim();

        switch (choice)
        {
            case "1":
                //
                break;
            case "2":
                RegisterPatient();
                break;
            default:
                break;
        }
    }
}