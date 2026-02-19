using DocotAppointmentSystem.Enums;
using DocotAppointmentSystem.Models;
using DocotAppointmentSystem.Services;

namespace DocotAppointmentSystem;

class Program
{
    static void Main(string[] args)
    {
        do
        {
            Console.WriteLine("Main Menu\n 1. Login\n 2. Register\n 3. Exit\n");
            Console.WriteLine("Choose an option:");
            string choice = Console.ReadLine()!.Trim();
            // bool proceed = true;
            switch (choice)
            {
                case "1":
                    AuthentificationManager.Login();
                    break;
                case "2":
                    AuthentificationManager.RegisterPatient();
                    break;
                case "3":
                    return;
                default:
                    break;
            }
        } while (true);

    }
}