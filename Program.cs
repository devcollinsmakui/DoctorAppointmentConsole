using DocotAppointmentSystem.Enums;
using DocotAppointmentSystem.Models;
using DocotAppointmentSystem.Services;

namespace DocotAppointmentSystem;

class Program
{
    List<Patient> patients = AppointmentManager.Patients;
    public void RegisterPatient()
    {
        bool correct = true;
        Console.WriteLine("Enter name: ");
        string name = Console.ReadLine()!;

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

        int age;
        do
        {
            Console.WriteLine("Enter Age: ");
            correct = int.TryParse(Console.ReadLine(), out age);
        } while (!correct);

        Gender gender = Gender.Male;
        string WorkStationNumber;

        do
        {
            correct = true;
            Console.WriteLine("Enter Gender: ");
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

        //add new user object to list
        patients.Add(new Patient { Name = name, Password = password, Age = age,Gender = gender});
        Console.WriteLine("User registered successfullly, UserID is {0}", patients.Last().PatientID);

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
                //
                break;
            default:
                break;
        }
    }
}