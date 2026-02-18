using System;

namespace DocotAppointmentSystem.Models;

public class Appointment
{
    public static int tid = 1;
    public int AppointmentID {get;}
    public int PatientID {get; set;}
    public int DoctorID {get; set;}
    public DateTime Date {get; set;}
    public required string Problem {get; set;}

    public Appointment()
    {
        AppointmentID = tid++;
    }
}
