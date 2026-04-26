using System;

namespace Lab5_Version3
{
    public partial class DigitalPlatform
    {
        public void RecommendCourse(Youth youth)
        {
            if (youth.Rating < 60)
                courseName = "Базовий курс";
            else if (youth.Rating < 85)
                courseName = "Практичний курс";
            else
                courseName = "Професійний курс";
        }

        public void EvaluateProject(string projectName, int grade)
        {
            for (int i = 0; i < projectsCount; i++)
            {
                if (projects[i].Name == projectName)
                {
                    projects[i].EvaluateResult(grade);
                    projects[i].ChangeStatus("Завершено");
                    break;
                }
            }
        }
    }
}