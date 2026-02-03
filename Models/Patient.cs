using System;
using DocotAppointmentSystem.Enums;

namespace DocotAppointmentSystem.Models;

public class Patient
{
    private int id = 0;
    public int PatientID {get;set;}
    public required string Password {get; set;}
    public required string Name {get;set;}
    public int Age {get; set;}
    public Gender Gender {get; set;}

    public Patient()
    {
        PatientID = id++;
    }
}
