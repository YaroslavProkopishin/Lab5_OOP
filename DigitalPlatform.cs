using System;
using System.Security.Cryptography.X509Certificates;

namespace Lab5_Version3
{
    public partial class DigitalPlatform : SubjectDigitalSpace
    {
       
        private int participantsCount;
        private Project[] projects;
        private int projectsCount;
        private string courseName;

        public DigitalPlatform() : base()
        {
            participantsCount = 0;
            projects = new Project[10];
            projectsCount = 0;
            courseName = "";
        }

        public DigitalPlatform(string platformName, bool isActive, int participantsCount, string courseName)
            : base(platformName, isActive)
        {
            this.participantsCount = participantsCount;
            this.courseName = courseName;
            projects = new Project[10];
            projectsCount = 0;
        }

        public DigitalPlatform(DigitalPlatform other) : base(other)
        {
            participantsCount = other.participantsCount;
            courseName = other.courseName;
            projectsCount = other.projectsCount;
            projects = new Project[10];

            for (int i = 0; i < projectsCount; i++)
                projects[i] = new Project(other.projects[i]);
        }

        public string PlatformName
        {
            get { return Name; }
            set { Name = value; }
        }

        public int ParticipantsCount
        {
            get { return participantsCount; }
            set
            {
                if (value >= 0)
                    participantsCount = value;
            }
        }

        public string CourseName
        {
            get { return courseName; }
            set { courseName = value; }
        }

        public void AddProject(string name, string sphere, double difficulty, string requiredSkill, string status)
        {
            if (projectsCount < projects.Length)
            {
                projects[projectsCount] = new Project(name, sphere, difficulty, requiredSkill, status);
                projectsCount++;
            }
        }

        public Project SelectProjectForYouth(Youth youth)
        {
            for (int i = 0; i < projectsCount; i++)
            {
                if (projects[i].Status == "Вільний" || projects[i].Status == "Очікує виконавця")
                {
                    for (int j = 0; j < youth.SkillsCount; j++)
                    {
                        if (projects[i].RequiredSkill.ToLower() == youth.Skills[j].ToLower())
                            return projects[i];
                    }
                }
            }
            return null;
        }

        public bool AssignProject(Youth youth)
        {
            if (!youth.IsActive)
            {
                Console.WriteLine("Профіль не активний.");
                return false;
            }

            if (youth.IsBusy)
            {
                Console.WriteLine("Користувач не може бути призначений на кілька проєктів одночасно.");
                return false;
            }

            Project selectedProject = SelectProjectForYouth(youth);

            if (selectedProject == null)
            {
                Console.WriteLine("Проєкт недоступний для призначення.");
                return false;
            }

            if (selectedProject.Status != "Вільний" && selectedProject.Status != "Очікує виконавця")
            {
                Console.WriteLine("Проєкт недоступний для призначення.");
                return false;
            }

            if (!selectedProject.AssignPerformer(youth.Id, youth.FullName))
            {
                Console.WriteLine("Проєкт недоступний для призначення.");
                return false;
            }

            youth.IsBusy = true;
            youth.CurrentProject = selectedProject;

            Console.WriteLine("Користувачу " + youth.FullName + " призначено проєкт: " + selectedProject.Name);
            Console.WriteLine(selectedProject.GetAssignmentMessage());
            return true;
        }

        public string GetProjectsText()
        {
            string result = "";
            for (int i = 0; i < projectsCount; i++)
                result += projects[i].ToString() + "\n";
            return result;
        }

        public static DigitalPlatform operator +(DigitalPlatform platform, int value)
        {
            if (value > 0)
            {
                platform.ParticipantsCount += value;
            }
            return platform;
        }

        public static DigitalPlatform operator -(DigitalPlatform platform, int value)
        {
          if( value > 0)
            {
                platform.ParticipantsCount -= value;
                if (platform.ParticipantsCount < 0)
                    platform.ParticipantsCount = 0;
            }
            return platform;
        }

        public static bool operator >(DigitalPlatform platform1, DigitalPlatform platform2)
        {
            return platform1.projectsCount > platform2.projectsCount;
        }
        public static bool operator <(DigitalPlatform platform1, DigitalPlatform platform2)
        {
            return platform1.projectsCount < platform2.projectsCount;
        }
       
        public static bool operator ==(DigitalPlatform platform1, DigitalPlatform platform2)
        {
            return platform1.PlatformName == platform2.PlatformName;
        }

        public static bool operator !=(DigitalPlatform platform1, DigitalPlatform platform2)
        {
            return platform1.PlatformName != platform2.PlatformName;
        }

        public override bool Equals(object obj)
        {
            if (obj is DigitalPlatform other)
                return PlatformName == other.PlatformName;

            return false;
        }

        public override int GetHashCode()
        {
            return PlatformName.GetHashCode();
        }


        public static DigitalPlatform operator ++(DigitalPlatform platform)
        {
            platform.ParticipantsCount++;
            return platform;
        }

        public static DigitalPlatform operator --(DigitalPlatform platform)
        {
            platform.ParticipantsCount--;
            if (platform.ParticipantsCount < 0)
                platform.ParticipantsCount = 0;
            return platform;
        }

        public override string GetInfo()
        {
            return "Цифрова платформа: " + PlatformName + "\n" +
           "Активність платформи: " + (IsActive ? "Так" : "Ні") + "\n" +
           "Кількість учасників: " + ParticipantsCount + "\n" +
           "Рекомендований курс: " + CourseName;
        }

        public string GenerateReport(Youth youth)
        {
            return "=== ЗВІТ ЦИФРОВОЇ ПЛАТФОРМИ ===\n" +
                   "Платформа: " + PlatformName + "\n" +
                   "Активність платформи: " + (IsActive ? "Так" : "Ні") + "\n" +
                   "Кількість учасників: " + participantsCount + "\n" +
                   "Користувач:\n" + youth.ToString() + "\n" +
                   "Проєкти:\n" + GetProjectsText() +
                   "Рекомендований курс: " + courseName;
        }
    }
}