using System;

namespace DocotAppointmentSystem.Models;

public class Appointment
{
    public int AppointmentID {get; set;}
    public int PatientID {get; set;}
    public int DoctorID {get; set;}
    public DateTime Date {get; set;}
    public required string Problem {get; set;}
}
