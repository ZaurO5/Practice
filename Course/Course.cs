using System;
using System.Collections.Generic;
using System.Linq;

public class Course
{
    public string Name { get; set; }
    public List<Group> Groups { get; set; }

    public Course(string name)
    {
        Name = name;
        Groups = new List<Group>();
    }

    public void AddGroup(Group group)
    {
        if (Groups.Any(g => g.Name == group.Name))
        {
            Console.WriteLine("Eyni adli qrup mövcuddur.");
            return;
        }
        Groups.Add(group);
    }

    public void ListGroups()
    {
        foreach (var group in Groups)
        {
            Console.WriteLine($"Qrup: {group.Name}, Limit: {group.Limit}");
        }
    }

    public Group GetGroupByName(string name)
    {
        return Groups.FirstOrDefault(g => g.Name == name);
    }

    public void RemoveGroup(string name)
    {
        var group = GetGroupByName(name);
        if (group != null)
        {
            Groups.Remove(group);
            Console.WriteLine($"{name} qrupu silindi.");
        }
        else
        {
            Console.WriteLine($"{name} qrupu tapilmadi.");
        }
    }
}

public class Group
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Limit { get; set; }
    public List<Student> Students { get; set; }

    public Group(string id, string name, int limit)
    {
        Id = id;
        Name = name;
        Limit = limit;
        Students = new List<Student>();
    }

    public void AddStudent(Student student)
    {
        if (Students.Count >= Limit)
        {
            Console.WriteLine("Qrup limit doludur.");
            return;
        }
        if (Students.Any(s => s.Id == student.Id))
        {
            Console.WriteLine("Eyni Id-li student mövcuddur.");
            return;
        }
        Students.Add(student);
    }

    public void ListStudents()
    {
        foreach (var student in Students)
        {
            Console.WriteLine($"Student ID: {student.Id}, Name: {student.Name}, Surname: {student.Surname}, Age: {student.Age}, Grade: {student.Grade}");
        }
    }

    public void RemoveStudent(string studentId)
    {
        var student = Students.FirstOrDefault(s => s.Id == studentId);
        if (student != null)
        {
            Students.Remove(student);
            Console.WriteLine($"{studentId} ID-li student silindi.");
        }
        else
        {
            Console.WriteLine($"{studentId} ID-li student tapilmadi.");
        }
    }
}

public class Student
{
    private static int _idCounter = 1;
    public string Id { get; private set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public double Grade { get; set; }

    public Student(string name, string surname, int age, double grade)
    {
        Id = _idCounter.ToString();
        _idCounter++;
        Name = name;
        Surname = surname;
        Age = age;
        Grade = grade;
    }
}
