using System;
using System.Collections.Generic;

public class Hospital
{
    public List<Doctor> Doctors { get; } = new List<Doctor>();

    public void AddDoctor(Doctor doctor)
    {
        Doctors.Add(doctor);
    }

    public void ViewAllDoctors()
    {
        Console.WriteLine("All Doctors:");
        foreach (var doctor in Doctors)
        {
            Console.WriteLine($"Name: {doctor.Name}, Specialization: {doctor.Specialization}");
        }
    }

    public bool ScheduleAppointment(string doctorName, string patientName, DateTime date)
    {
        foreach (var doctor in Doctors)
        {
            if (doctor.Name == doctorName)
            {
                if (doctor.IsAvailable(date))
                {
                    doctor.Appointments.Add(new Appointment { PatientName = patientName, Date = date });
                    return true;
                }
                else
                {
                    Console.WriteLine("This time slot is not available for appointment.");
                    return false;
                }
            }
        }
        Console.WriteLine("Doctor not found.");
        return false;
    }

    public void ViewAppointmentsOfDoctor(string doctorName)
    {
        foreach (var doctor in Doctors)
        {
            if (doctor.Name == doctorName)
            {
                Console.WriteLine($"Appointments of Dr. {doctorName}:");
                foreach (var appointment in doctor.Appointments)
                {
                    Console.WriteLine($"Patient: {appointment.PatientName}, Date: {appointment.Date}");
                }
                return;
            }
        }
        Console.WriteLine("Doctor not found.");
    }
}
