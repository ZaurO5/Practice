using System;
class Program
{
    static void Main(string[] args)
    {
        Hospital hospital = new Hospital();

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add doctor");
            Console.WriteLine("2. View all doctors");
            Console.WriteLine("3. Schedule appointment");
            Console.WriteLine("4. View appointments of doctor");
            Console.WriteLine("5. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddDoctor(hospital);
                    break;
                case "2":
                    hospital.ViewAllDoctors();
                    break;
                case "3":
                    ScheduleAppointment(hospital);
                    break;
                case "4":
                    ViewAppointmentsOfDoctor(hospital);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice! Please try again.");
                    break;
            }
        }
    }

    static void AddDoctor(Hospital hospital)
    {
        Console.Write("Enter doctor name: ");
        string name = Console.ReadLine();

        Console.Write("Enter doctor's specialization: ");
        string specialization = Console.ReadLine();

        hospital.AddDoctor(new Doctor { Name = name, Specialization = specialization });
    }

    static void ScheduleAppointment(Hospital hospital)
    {
        Console.Write("Enter doctor's name: ");
        string doctorName = Console.ReadLine();

        Console.Write("Enter patient's name: ");
        string patientName = Console.ReadLine();

        Console.Write("Enter appointment date (MM/dd/yyyy hh:mm tt): ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        if (hospital.ScheduleAppointment(doctorName, patientName, date))
            Console.WriteLine("Appointment scheduled successfully.");
    }

    static void ViewAppointmentsOfDoctor(Hospital hospital)
    {
        Console.Write("Enter doctor's name: ");
        string doctorName = Console.ReadLine();

        hospital.ViewAppointmentsOfDoctor(doctorName);
    }
}
