using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLib
{
    public class Student
    {
        public static List<Student> studentsList = new List<Student>();

        private static int id = 0;

        private string _FIO { get; set; }
        private string _group { get; set; }
        private DateTime _bornDate { get; set; }

        public int idStudent { get; set; }

        public Student(string FIO, string group, DateTime bornDate)
        {
            _FIO = FIO;
            _group = group;
            _bornDate = bornDate;
            idStudent = id++;
        }

        public static void AddStudent(Student student)
        {
            studentsList.Add(student);
        }

        public static void EditStudent(string fio, string group, DateTime bornDate, int id)
        {
            bool studentExist = false;
            for (int i = 0; i < studentsList.Count; i++)
            {
                if (i == id)
                {
                    studentsList[i]._FIO = fio;
                    studentsList[i]._group = group;
                    studentsList[i]._bornDate = bornDate;
                    studentExist = true;
                    break;
                }
            }
            if (studentExist == false)
            {
                Console.WriteLine("Студента с таким id не существует!");
            }
        }

        public static void RemoveStudent(int id)
        {
            bool studentExist = false;
            foreach (Student student in studentsList)
            {
                if (student.idStudent == id)
                {
                    studentsList.Remove(student);
                    studentExist = true;
                    break;
                }
            }
            if (studentExist == false)
            {
                Console.WriteLine("Студента с таким id не существует!");
            }
        }

        public static void OutputAllStudent()
        {
            int i = 1;
            if (studentsList == null)
            {
                Console.WriteLine("Не одного студента нет в списке!!!");
            }
            else
            {
                foreach (Student student in studentsList)
                {
                    Console.WriteLine($"{i++}. ФИО: {student._FIO}");
                }
            }
           
        }

        public static void OutputID(int id)
        {
            bool studentExist = false;
            foreach (Student student in studentsList)
            {
                if (student.idStudent == id)
                {
                    Console.WriteLine($"ФИО: {student._FIO}, Группа: {student._group}, Дата рождения: " +
                        $"{student._bornDate.ToString().Substring(0, 10)}, Id студента: {student.idStudent}");
                    studentExist = true;
                    break;
                }
            }
            if (studentExist == false)
            {
                Console.WriteLine("Студент c таким id не существует!");
            }
        }

        public static void OutputGrowth(int id)
        {
            bool studentExist = false;
            foreach (Student student in studentsList)
            {
                if (student.idStudent == id)
                {
                    var date = DateTime.Now;
                    var year = date.Year - student._bornDate.Year;
                    if (date.Month < student._bornDate.Month || (date.Month == student._bornDate.Month && date.Day > student._bornDate.Day))
                    {
                        year--;
                    }
                    Console.WriteLine($"ФИО: {student._FIO} возрост студента: " + year);
                    studentExist = true;
                    break;
                }
            }
            if (studentExist == false)
            {
                Console.WriteLine("Студента с таким id не существует!");
            }
        }

        public int GrowthStudent(int id)
        {
            int year = 0;
            foreach (Student student in studentsList)
            {
                if (student.idStudent == id)
                {
                    var date = DateTime.Now;
                    year = date.Year - student._bornDate.Year;
                    if (date.Month < student._bornDate.Month || (date.Month == student._bornDate.Month && date.Day > student._bornDate.Day))
                    {
                        year--;
                    }
                }
            }
            return year;
        }


    }
}
