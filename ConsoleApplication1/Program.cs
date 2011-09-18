using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> names = new List<string> { "2dddd1dd", "4dddd22dd", "5ddd332ddd" };
            IEnumerable<string> names2 = new List<string> { "dd", "", "df", "" };
            names = names.Where(x => x != "4dddd22dd");
            names = names.Union(names2);
            List<Student> students = createStudents();

            students = students.Where<Student>((student) => { return student.Name.Contains('5'); }).ToList();

            students.Do<Student>(student => Console.WriteLine(student.Name));


            names2.Do<string>(s =>
            {
                if (s != string.Empty)
                {
                    Console.WriteLine(s);
                }
            }
            );
            Console.Read();
        }
        private static void print<T>(IEnumerable<T> names)
        {
            foreach (var name in names)
            {
                Console.WriteLine(name.ToString());
            }
        }

        private static List<Student> createStudents()
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i < 10; i++)
            {
                students.Add(new Student("student_" + i));
            }
            return students;
        }
    }


    public delegate void Func<T>(T t);
    public class Student
    {
        private string name;
        public string Name
        {
            get { return name; }
        }
        public Student(string name)
        {
            this.name = name;
        }
    }

    public static class Extension
    {
        public static void Do<T>(this IEnumerable<T> enumerable, Func<T> func)
        {
            foreach (T e in enumerable)
            {
                func(e);
            }
        }
    }
}
