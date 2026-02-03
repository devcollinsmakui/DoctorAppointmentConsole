using System;

namespace DocotAppointmentSystem.Models;

public class Doctor
{
    public int DoctorID {get; set;}
    public required string Name {get; set;}
    public required string Department {get; set;}
}
