using Lab5_3;
using System;
using System.Text;

namespace Lab5_Version3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;



            Service service = new Service(".txt", "report.txt", "");

            Youth youth = new Youth();  
            youth.IsActive = true;

            youth.FullName = service.ReadFromConsole("Введіть ім'я: ");
            youth.Age = int.Parse(service.ReadFromConsole("Введіть вік: "));
            youth.Id = service.ReadFromConsole("Введіть ID користувача: ");

            int skillsNumber = int.Parse(service.ReadFromConsole("Скільки навичок хочете додати? "));

            for (int i = 0; i < skillsNumber; i++)
            {
                string skill = service.ReadFromConsole("Введіть навичку " + (i + 1) + ": ");
                youth.AddSkill(skill);
            }

            youth.CompletedProjectsCount = int.Parse(
                service.ReadFromConsole("Введіть кількість завершених проєктів: "));

            int count = int.Parse(service.ReadFromConsole("Скільки проєктів врахувати для рейтингу? "));

            int[] marks = new int[count];
            double[] difficulty = new double[count];

            for (int i = 0; i < count; i++)
            {
                marks[i] = int.Parse(service.ReadFromConsole("Оцінка за проєкт " + (i + 1) + ": "));
                difficulty[i] = double.Parse(service.ReadFromConsole("Коефіцієнт складності " + (i + 1) + ": "));
            }

            youth.CalculateRating(marks, difficulty, count);
            youth.EvaluateExperience();

            DigitalPlatform platform = new DigitalPlatform();
            platform.PlatformName = "Digital Career Platform";
            platform.IsActive = true;
            platform.ParticipantsCount = 1;

            platform.AddProject("C# Backend", "Backend", 1.3, "C#", "Вільний");
            platform.AddProject("Web Design", "Design", 1.1, "Figma", "Вільний");
            platform.AddProject("Python Analytics", "Analytics", 1.4, "Python", "Вільний");
            platform.AddProject("Java Internship", "Backend", 1.2, "Java", "Вільний");

            platform.RecommendCourse(youth);
            platform.AssignProject(youth);

            string report = platform.GenerateReport(youth);
            platform = platform + 5;

            Console.WriteLine("Учасників стало: " + platform.ParticipantsCount);

            service.WriteToConsole("\n" + report);
            service.WriteToFile(report);
            service.WriteToConsole("\nЗвіт записано у файл report.txt");

            Console.WriteLine();

            Console.Write("Введіть кількість оцінок: ");
            int n = int.Parse(Console.ReadLine());

            int[] grades = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write("Введіть оцінку " + (i + 1) + ": ");
                grades[i] = int.Parse(Console.ReadLine());
            }

            Mentor.ShowGradesAnalysis(grades);

            Console.WriteLine("\n=== Демонстрація SetOfProject ===");

            SetOfProject set = new SetOfProject();

            Project project1 = new Project("C# Backend", "Backend", 1.3, "C#", "Вільний");
            Project project2 = new Project("Web Design", "Design", 1.1, "Figma", "Вільний");

            set.AddProject(project1);
            set.AddProject(project2);

            Console.WriteLine("Перший проєкт:");
            Console.WriteLine(set[0]);

            Console.WriteLine("Другий проєкт:");
            Console.WriteLine(set[1]);

            Console.ReadKey();
        }
    }
}