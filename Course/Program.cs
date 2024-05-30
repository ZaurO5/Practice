class Program
{
    static void Main(string[] args)
    {
        Course course = new Course("Code Academy");

        while (true)
        {
            Console.WriteLine("\nMenyu:");
            Console.WriteLine("1. Qrup elave et");
            Console.WriteLine("2. Qruplari gor");
            Console.WriteLine("3. Qrupu redakte et");
            Console.WriteLine("4. Qrupu sil");
            Console.WriteLine("5. Qrupa student elave et");
            Console.WriteLine("6.1 Qrupdaki studentleri gor");
            Console.WriteLine("6.2 Kursdaki studentleri gor");
            Console.WriteLine("7. Studentler uzre axtaris");
            Console.WriteLine("8. Qrupdan student sil");
            Console.WriteLine("9. Qrupdaki studenti editle");
            Console.WriteLine("10. Exit");

            Console.Write("\nSeciminizi daxil edin: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddGroup(course);
                    break;
                case 2:
                    course.ListGroups();
                    break;
                case 3:
                    EditGroup(course);
                    break;
                case 4:
                    DeleteGroup(course);
                    break;
                case 5:
                    AddStudentToGroup(course);
                    break;
                case 6:
                    ListStudentsInGroup(course);
                    break;
                case 7:
                    SearchStudents(course);
                    break;
                case 8:
                    RemoveStudentFromGroup(course);
                    break;
                case 9:
                    EditStudentInGroup(course);
                    break;
                case 10:
                    return;
                default:
                    Console.WriteLine("Yanlis secim. Yeniden cehd edin.");
                    break;
            }
        }
    }

    static void AddGroup(Course course)
    {
        Console.Write("Qrup ID daxil edin: ");
        string id = Console.ReadLine();
        Console.Write("Qrup adi daxil edin: ");
        string name = Console.ReadLine();
        Console.Write("Qrup limitini daxil edin: ");
        int limit = int.Parse(Console.ReadLine());

        Group group = new Group(id, name, limit);
        course.AddGroup(group);
    }

    static void EditGroup(Course course)
    {
        Console.Write("Redakte etmek istediyiniz qrupun adini daxil edin: ");
        string name = Console.ReadLine();
        Group group = course.GetGroupByName(name);

        if (group != null)
        {
            Console.Write("Yeni qrup adini daxil edin: ");
            string newName = Console.ReadLine();
            Console.Write("Yeni qrup limitini daxil edin: ");
            int newLimit = int.Parse(Console.ReadLine());

            group.Name = newName;
            group.Limit = newLimit;
            Console.WriteLine("Qrup redakte olundu.");
        }
        else
        {
            Console.WriteLine("Qrup tapilmadi.");
        }
    }

    static void DeleteGroup(Course course)
    {
        Console.Write("Silmek istediyiniz qrupun adini daxil edin: ");
        string name = Console.ReadLine();
        course.RemoveGroup(name);
    }

    static void AddStudentToGroup(Course course)
    {
        Console.WriteLine("Qruplar:");
        course.ListGroups();
        Console.Write("Student elave etmek istediyiniz qrupun adini daxil edin: ");
        string groupName = Console.ReadLine();
        Group group = course.GetGroupByName(groupName);

        if (group != null)
        {
            Console.Write("Student adi daxil edin: ");
            string name = Console.ReadLine();
            Console.Write("Student soyadi daxil edin: ");
            string surname = Console.ReadLine();
            Console.Write("Student yasi daxil edin: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Studentin qiymetini daxil edin: ");
            double grade = double.Parse(Console.ReadLine());

            Student student = new Student(name, surname, age, grade);
            group.AddStudent(student);
        }
        else
        {
            Console.WriteLine("Qrup tapilmadi.");
        }
    }

    static void ListStudentsInGroup(Course course)
    {
        Console.WriteLine("Qruplar:");
        course.ListGroups();
        Console.Write("Studentlerini gormek istediyiniz qrupun adini daxil edin: ");
        string groupName = Console.ReadLine();
        Group group = course.GetGroupByName(groupName);

        if (group != null)
        {
            group.ListStudents();
        }
        else
        {
            Console.WriteLine("Qrup tapilmadi.");
        }
    }

    static void SearchStudents(Course course)
    {
        Console.Write("Axtarish deyerini daxil edin: ");
        string searchString = Console.ReadLine().ToLower();

        foreach (var group in course.Groups)
        {
            foreach (var student in group.Students)
            {
                if (student.Name.ToLower().Contains(searchString))
                {
                    Console.WriteLine($"Student ID: {student.Id}, Name: {student.Name}, Surname: {student.Surname}, Age: {student.Age}, Grade: {student.Grade}");
                }
            }
        }
    }

    static void RemoveStudentFromGroup(Course course)
    {
        Console.WriteLine("Qruplar:");
        course.ListGroups();
        Console.Write("Student silmek istediyiniz qrupun adini daxil edin: ");
        string groupName = Console.ReadLine();
        Group group = course.GetGroupByName(groupName);

        if (group != null)
        {
            group.ListStudents();
            Console.Write("Silmek istediyiniz studentin ID-sini daxil edin: ");
            string studentId = Console.ReadLine();
            group.RemoveStudent(studentId);
        }
        else
        {
            Console.WriteLine("Qrup tapilmadi.");
        }
    }

    static void EditStudentInGroup(Course course)
    {
        Console.WriteLine("Qruplar:");
        course.ListGroups();
        Console.Write("Student redakte etmek istediyiniz qrupun adini daxil edin: ");
        string groupName = Console.ReadLine();
        Group group = course.GetGroupByName(groupName);

        if (group != null)
        {
            group.ListStudents();
            Console.Write("Redakte etmek istediyiniz studentin ID-sini daxil edin: ");
            string studentId = Console.ReadLine();
            var student = group.Students.FirstOrDefault(s => s.Id == studentId);

            if (student != null)
            {
                Console.Write("Yeni student adi daxil edin: ");
                string newName = Console.ReadLine();
                Console.Write("Yeni student soyadi daxil edin: ");
                string newSurname = Console.ReadLine();
                Console.Write("Yeni student yasi daxil edin: ");
                int newAge = int.Parse(Console.ReadLine());
                Console.Write("Yeni student qiymetini daxil edin: ");
                double newGrade = double.Parse(Console.ReadLine());

                student.Name = newName;
                student.Surname = newSurname;
                student.Age = newAge;
                student.Grade = newGrade;
                Console.WriteLine("Student melumatlari redakte olundu.");
            }
            else
            {
                Console.WriteLine("Student tapilmadi.");
            }
        }
        else
        {
            Console.WriteLine("Qrup tapilmadi.");
        }
    }
}
