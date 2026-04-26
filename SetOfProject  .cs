using Lab5_Version3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_3
{
    public class SetOfProject
    {
        private Project[] projects;
        private int count;

        public SetOfProject()
        {
            projects = new Project[10];
            count = 0;
        }

        public void AddProject(Project project)
        {
            if (count < projects.Length)
            {
                projects[count] = project;
                count++;
            }
        }

        public Project this[int index]
        {
            get
            {
                if (index >= 0 && index < count)
                    return projects[index];

                return null;
            }

            set
            {
                if (index >= 0 && index < count)
                    projects[index] = value;
            }
        }
    }
}
