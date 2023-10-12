using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace Day13_FileIO
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long PhoneNumber { get; set; }
        public int Age { get; set; }
    }
    internal class Program
    {
        static void SaveDataToCSVfile(List<Student> students)
        {
            string csvpath = @"C:\Users\DELL\source\repos\Day13-FileIO\Student.csv";
            var writer = File.AppendText(csvpath);
            foreach (Student student in students)
            {
                writer.WriteLine("Id : " + student.Id);
                writer.WriteLine("Name : " + student.Name);
                writer.WriteLine("PhoneNumber : " + student.PhoneNumber);
                writer.WriteLine("Age : " + student.Age);
            }
            writer.Close();
        }
        static void ReadDataFromCSVFile()
        {
            string csvpath = @"C:\Users\DELL\source\repos\Day13-FileIO\Student.csv";
            using (var reader = new StreamReader(csvpath))

            {
                string s = " ";
                while ((s = reader.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }

            }
        }
        static void SaveDataToJsonFile(List<Student> students)
        {
            string path = @"C:\Users\DELL\source\repos\Day13-FileIO\StudentData.json";

            using (StreamWriter writer = new StreamWriter(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                using (JsonWriter jsonWriter = new JsonTextWriter(writer))
                {
                    foreach (Student student in students)
                    {
                        writer.WriteLine("Id : " + student.Id);
                        writer.WriteLine("Name : " + student.Name);
                        writer.WriteLine("PhoneNumber : " + student.PhoneNumber);
                        writer.WriteLine("Age : " + student.Age);
                    }
                }
            }
        }
        static void ReadDataFromJson()
        {
            string path = @"C:\Users\DELL\source\repos\Day13-FileIO\StudentData.json";
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);

                Console.WriteLine("Data read from file:");
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
        static void SaveDataToFile(List<Student> students)
        {
            string path = @"C:\Users\DELL\source\repos\Day13-FileIO\StudentDetails.txt";

            using (StreamWriter writer = new StreamWriter(path, true))
            {
                foreach(Student student in students)
                {
                    writer.WriteLine("Id : " + student.Id);
                    writer.WriteLine("Name : " + student.Name);
                    writer.WriteLine("PhoneNumber : " + student.PhoneNumber);
                    writer.WriteLine("Age : " + student.Age);
                }
            }
        }
        static void ReadDataFromFile()
        {
            string path = @"C:\Users\DELL\source\repos\Day13-FileIO\StudentDetails.txt";
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);

                Console.WriteLine("Data read from file:");
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student{Id=1,Name="Madhur",PhoneNumber=8295475016,Age=22}
            };
            SaveDataToFile(students);
            Console.WriteLine("Data Saved To File Succesfully");
            ReadDataFromFile();
            SaveDataToJsonFile(students);
            Console.WriteLine("Data Saved To Json File Succesfully");
            ReadDataFromJson();
            SaveDataToCSVfile(students);
            Console.WriteLine("Data Saved Succesfully in csv File");
            ReadDataFromCSVFile();

        }
    }
}
