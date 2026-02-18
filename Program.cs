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
            Console.WriteLine("Main Menu\n 1. Login\n 2. Register\n");
            Console.WriteLine("Choose an option:");
            string choice = Console.ReadLine()!.Trim();
            // bool proceed = true;
            switch (choice)
            {
                case "1":
                    //
                    break;
                case "2":
                    AuthentificationManager.RegisterPatient();
                    break;
                default:
                    break;
            }
        } while (true);
    }
}