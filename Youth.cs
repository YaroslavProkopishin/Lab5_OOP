using System;
using System.Xml.Linq;

namespace Lab5_Version3
{
    public class Youth : SubjectDigitalSpace
    {
        private int age;
        private string id;
        private string[] skills;
        private int skillsCount;
        private double rating;
        private int completedProjectsCount;
        private string profileStatus;
        private bool isBusy;
        private Project currentProject;

        public Youth() : base()
        {
            age = 0;
            id = "";
            skills = new string[10];
            skillsCount = 0;
            rating = 0;
            completedProjectsCount = 0;
            profileStatus = "";
            isBusy = false;
            currentProject = null;
        }

        public Youth(string fullName, bool isActive, int age, string id, string[] skills, int skillsCount,
            double rating, int completedProjectsCount, string profileStatus, bool isBusy) : base(fullName, isActive)
        {
            this.age = age;
            this.id = id;
            this.skills = new string[10];
            this.skillsCount = skillsCount;

            for (int i = 0; i < skillsCount; i++)
            {
                this.skills[i] = skills[i];
            }

            this.rating = rating;
            this.completedProjectsCount = completedProjectsCount;
            this.profileStatus = profileStatus;
            this.isBusy = isBusy;
        }

        public Youth(Youth other) : base(other)
        {
            age = other.age;
            id = other.id;
            skills = new string[10];
            skillsCount = other.skillsCount;

            for (int i = 0; i < other.skillsCount; i++)
            {
                skills[i] = other.skills[i];
            }

            rating = other.rating;
            completedProjectsCount = other.completedProjectsCount;
            profileStatus = other.profileStatus;
            isBusy = other.isBusy;
        }

        public Project CurrentProject
        {
            get { return currentProject; }
            set { currentProject = value; }
        }

        public string FullName
        {
            get { return Name; }
            set { Name = value; }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value >= 0)
                    age = value;
            }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public double Rating
        {
            get { return rating; }
            set
            {
                if (value >= 0)
                    rating = value;
            }
        }

        public int CompletedProjectsCount
        {
            get { return completedProjectsCount; }
            set
            {
                if (value >= 0)
                    completedProjectsCount = value;
            }
        }

        public string ProfileStatus
        {
            get { return profileStatus; }
            set { profileStatus = value; }
        }

        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; }
        }

        public string[] Skills
        {
            get { return skills; }
        }

        public int SkillsCount
        {
            get { return skillsCount; }
        }

        public void AddSkill(string skill)
        {
            if (string.IsNullOrWhiteSpace(skill))
                return;

            if (skillsCount >= skills.Length)
            {
                Console.WriteLine("Максимум можна додати 10 навичок");
                return;
            }

            skills[skillsCount] = skill;
            skillsCount++;
        }

        public double CalculateRating(int[] marks, double[] difficulty, int count)
        {
            if (count <= 0)
            {
                rating = 0;
                return rating;
            }

            double sum = 0;

            for (int i = 0; i < count; i++)
            {
                sum += marks[i] * difficulty[i];
            }

            rating = sum / count;
            return rating;
        }

        public void EvaluateExperience()
        {
            if (completedProjectsCount == 0)
                profileStatus = "Новачок";
            else if (completedProjectsCount <= 2)
                profileStatus = "Стабільний";
            else
                profileStatus = "Топ";
        }

        public string GetSkillsText()
        {
            string result = "";

            for (int i = 0; i < skillsCount; i++)
            {
                result += skills[i];
                if (i < skillsCount - 1)
                    result += ", ";
            }

            return result;
        }

        public static Youth operator +(Youth youth, double value)
        {
            youth.rating += 10;
            return youth;
        }

        public static Youth operator -(Youth youth, double value)
        {
            youth.rating -= 10;

            if(youth.rating < 0)
            {
                youth.rating = 0;
            }
            return youth;
        }

        public static bool operator >(Youth y1, Youth y2)
        {
            return y1.skillsCount > y2.skillsCount;
        }

        public static bool operator <(Youth y1, Youth y2)
        {
            return y1.skillsCount < y2.skillsCount;
        }

        public static Youth operator ++(Youth youth)
        {
            youth.Rating++;
            return youth;
        }
        public static Youth operator --(Youth youth)
        {
            youth.Rating--;
            if (youth.Rating < 0)
                youth.Rating = 0;
            return youth;
        }
        public static bool operator ==(Youth y1, Youth y2)
        {
            if (ReferenceEquals(y1, y2))
                return true;

            if (y1 is null || y2 is null)
                return false;

            return y1.Rating == y2.Rating;
        }

        public static bool operator !=(Youth y1, Youth y2)
        {
            return !(y1 == y2);
        }


        public override bool Equals(object obj)
        {
            if (obj is Youth other)
                return this.Rating == other.Rating;

            return false;
        }

        public override int GetHashCode()
        {
            return Rating.GetHashCode();
        }

        public override string GetInfo()
        {
            return "Молодь: " + FullName + "\n" +
                   "Вік: " + Age + "\n" +
                   "ID: " + Id + "\n" +
                   "Навички: " + GetSkillsText() + "\n" +
                   "Рейтинг: " + Rating.ToString("F2") + "\n" +
                   "Статус профілю: " + ProfileStatus + "\n" +
                   "Активність профілю: " + (IsActive ? "Так" : "Ні");
        }

        public override string ToString()
        {
            return "Ім'я: " + FullName + "\n" +
                   "Вік: " + age + "\n" +
                   "ID: " + id + "\n" +
                   "Навички: " + GetSkillsText() + "\n" +
                   "Рейтинг: " + rating.ToString("F2") + "\n" +
                   "Кількість завершених проєктів: " + completedProjectsCount + "\n" +
                   "Статус: " + profileStatus + "\n" +
                   "Активний профіль: " + (IsActive ? "Так" : "Ні") + "\n" +
                   "Зайнятість: " + (isBusy ? "У роботі" : "Вільний");
        }
    }
}