using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_Version3
{
        public class Project
        {
            private string name;
            private string sphere;
            private double difficulty;
            private string requiredSkill;
            private string status;
            private string performerId;
            private string performerName;
            private int grade;
            private DateTime assignmentDate;
            private DateTime deadline;
            private bool trackerActive;
            private string briefLink;
            private string requirements;
            private string coordinatorContact;

            public Project()
            {
                name = "";
                sphere = "";
                difficulty = 1.0;
                requiredSkill = "";
                status = "Вільний";
                performerId = "";
                performerName = "";
                grade = 0;
                assignmentDate = DateTime.MinValue;
                deadline = DateTime.MinValue;
                trackerActive = false;
                briefLink = "";
                requirements = "";
                coordinatorContact = "";
            }

            public Project(string name, string sphere, double difficulty, string requiredSkill, string status)
            {
                this.name = name;
                this.sphere = sphere;
                this.difficulty = difficulty;
                this.requiredSkill = requiredSkill;
                this.status = status;
                performerId = "";
                performerName = "";
                grade = 0;
                assignmentDate = DateTime.MinValue;
                deadline = DateTime.MinValue;
                trackerActive = false;
                briefLink = "brief/" + name.Replace(" ", "_");
                requirements = "Виконати проєкт згідно з вимогами.";
                coordinatorContact = "coordinator@platform.com";
            }

            

            public Project(Project other)
            {
                name = other.name;
                sphere = other.sphere;
                difficulty = other.difficulty;
                requiredSkill = other.requiredSkill;
                status = other.status;
                performerId = other.performerId;
                performerName = other.performerName;

                grade = 0;

                assignmentDate = other.assignmentDate;
                deadline = other.deadline;
                trackerActive = other.trackerActive;
                briefLink = other.briefLink;
                requirements = other.requirements;
                coordinatorContact = other.coordinatorContact;
            }

        public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public string Sphere
            {
                get { return sphere; }
                set { sphere = value; }
            }

            public double Difficulty
            {
                get { return difficulty; }
                set
                {
                    if (value > 0)
                        difficulty = value;
                }
            }

            public string RequiredSkill
            {
                get { return requiredSkill; }
                set { requiredSkill = value; }
            }

            public string Status
            {
                get { return status; }
                set { status = value; }
            }

            public string PerformerId
            {
                get { return performerId; }
                set { performerId = value; }
            }

            public string PerformerName
            {
                get { return performerName; }
                set { performerName = value; }
            }

            public int Grade
            {
                get { return grade; }
                set
                {
                    if (value >= 0)
                        grade = value;
                }
            }

            public DateTime AssignmentDate
            {
                get { return assignmentDate; }
                set { assignmentDate = value; }
            }

            public DateTime Deadline
            {
                get { return deadline; }
                set { deadline = value; }
            }

            public bool TrackerActive
            {
                get { return trackerActive; }
                set { trackerActive = value; }
            }

            public string BriefLink
            {
                get { return briefLink; }
                set { briefLink = value; }
            }

            public string Requirements
            {
                get { return requirements; }
                set { requirements = value; }
            }

            public string CoordinatorContact
            {
                get { return coordinatorContact; }
                set { coordinatorContact = value; }
            }

            public bool AssignPerformer(string performerId, string performerName)
            {
                if (status != "Вільний" && status != "Очікує виконавця")
                    return false;

                this.performerId = performerId;
                this.performerName = performerName;
                assignmentDate = DateTime.Now;
                deadline = DateTime.Now.AddDays(14);
                trackerActive = true;
                status = "У роботі";
                return true;
            }

            public void ChangeStatus(string newStatus)
            {
                status = newStatus;
            }

            public void EvaluateResult(int grade)
            {
                if (grade >= 0)
                    this.grade = grade;
            }

            public static Project operator +(Project p1, Project p2)
            {
            Project result = new Project();

            result.Name = p1.Name + " & " + p2.Name;
            result.Sphere = p1.Sphere + " & " + p2.Sphere;
            result.Difficulty = (p1.Difficulty + p2.Difficulty) / 2;
            result.Status = "Вільний";

            return result;
            }

            public static Project operator -(Project p1, Project p2)
            {
                Project result = new Project();

                result.Name = p1.Name;
                result.Sphere = p1.Sphere;

                result.Difficulty = p1.Difficulty - p2.Difficulty;
                if (result.Difficulty < 1)
                result.Difficulty = 1;

                result.Status = "Вільний";

                return result;
            }


        public static bool operator ==(Project p1, Project p2)
            {
            if (ReferenceEquals(p1, p2))
                return true;

            if (p1 is null || p2 is null)
                return false;

            return p1.Difficulty == p2.Difficulty;
            }

            public static bool operator !=(Project p1, Project p2)
            {
                return !(p1 == p2);
            }

            public override bool Equals(object obj)
            {
            if (obj is Project other)
                return this.Difficulty == other.Difficulty;

            return false;
            }

            public override int GetHashCode()
            {
            return Difficulty.GetHashCode();
            }

            public static Project operator ++(Project p)
            {
                p.Difficulty++;
                return p;
            }

            public static Project operator --(Project p)
            {
            p.Difficulty--;
            if (p.Difficulty < 1)
                p.Difficulty = 1;
            return p;
            }

        public string GetAssignmentMessage()
            {
                return "Підтвердження призначення:\n" +
                       "Проєкт: " + name + "\n" +
                       "Виконавець: " + performerName + "\n" +
                       "ID виконавця: " + performerId + "\n" +
                       "Дата призначення: " + assignmentDate.ToString("dd.MM.yyyy HH:mm") + "\n" +
                       "Дедлайн: " + deadline.ToString("dd.MM.yyyy") + "\n" +
                       "Бриф: " + briefLink + "\n" +
                       "Вимоги: " + requirements + "\n" +
                       "Контакт координатора: " + coordinatorContact;
            }

            public override string ToString()
            {
                return "Проєкт: " + name +
                       ", Сфера: " + sphere +
                       ", Складність: " + difficulty +
                       ", Статус: " + status +
                       ", Виконавець: " + (performerName == "" ? "не призначено" : performerName) +
                       ", ID: " + (performerId == "" ? "немає" : performerId) +
                       ", Оцінка: " + grade;
            }
        }
}
