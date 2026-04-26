using System;

namespace Lab5_Version3
{
    public static class Mentor
    {
        public static int CalculateGradesAmplitude(int[] grades)
        {
            if (grades.Length == 0)
                return 0;

            int min = grades[0];
            int max = grades[0];

            for (int i = 1; i < grades.Length; i++)
            {
                if (grades[i] < min)
                    min = grades[i];

                if (grades[i] > max)
                    max = grades[i];
            }

            return max - min;
        }

        public static void ShowGradesAnalysis(int[] grades)
        {
            int amplitude = CalculateGradesAmplitude(grades);

            Console.WriteLine("Аналіз результатів проєктів:");
            Console.WriteLine("Амплітуда оцінок = " + amplitude);
        }
    }
}