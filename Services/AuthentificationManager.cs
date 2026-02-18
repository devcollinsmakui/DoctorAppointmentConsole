using System;
using DocotAppointmentSystem.Enums;
using DocotAppointmentSystem.Models;

namespace DocotAppointmentSystem.Services;

public class AuthentificationManager
{
    static List<Patient> patients = AppointmentManager.Patients;
    public static void RegisterPatient()
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
        patients.Add(new Patient { Name = name, Password = password, Age = age, Gender = gender});
        Console.WriteLine("User registered successfullly, UserID is {0}", patients.Last().PatientID);
        patients.ForEach(x => Console.WriteLine($"{x.PatientID}, {x.Password}, {x.Name}, {x.Age}, {x.Gender}"));

    }
}
