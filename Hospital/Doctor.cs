using System;
using System.Collections.Generic;

public class Doctor
{
    public string Name { get; set; }
    public string Specialization { get; set; }
    public List<Appointment> Appointments { get; } = new List<Appointment>();
    public HashSet<DateTime> BusySlots { get; } = new HashSet<DateTime>();

    public bool IsAvailable(DateTime date)
    {
        if (BusySlots.Contains(date))
            return false;
        return true;
    }

    public void AddBusySlot(DateTime date)
    {
        BusySlots.Add(date);
    }
}
