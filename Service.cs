using System;
using System.IO;

namespace Lab5_Version3
{
    public class Service
    {
        private string fileFormat;
        private string filePath;
        private string data;

        public Service()
        {
            fileFormat = ".txt";
            filePath = "report.txt";
            data = "";
        }

        public Service(string fileFormat, string filePath, string data)
        {
            this.fileFormat = fileFormat;
            this.filePath = filePath;
            this.data = data;
        }

        public Service(Service other)
        {
            fileFormat = other.fileFormat;
            filePath = other.filePath;
            data = other.data;
        }

        public string FileFormat
        {
            get { return fileFormat; }
            set { fileFormat = value; }
        }

        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        public string Data
        {
            get { return data; }
            set { data = value; }
        }

        public string ReadFromConsole(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        public void WriteToConsole(string message)
        {
            Console.WriteLine(message);
        }

        public void WriteToFile(string text)
        {
            File.WriteAllText(filePath, text);
        }

        public string ReadFromFile()
        {
            if (File.Exists(filePath))
                return File.ReadAllText(filePath);

            return "Файл не знайдено.";
        }
    }
}