using System;
using System.Collections.Generic;

namespace Number20
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            int simulationYear = 2020;
            List<Student> students = new List<Student>();
            
            // Симуляция 5 лет
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Введите количество поступивших студентов в {simulationYear}-м году: ");
                int n = int.Parse(Console.ReadLine());

                // Перевод студентов на следующий курс
                foreach (var t in students)
                {
                    if (t.NextCourse() == -1)
                    {
                        students.Remove(t);
                    }
                }
                
                // Добавление новых студентов в список
                for (int j = 0; j < n; j++)
                {
                    students.Add(new Student(simulationYear));
                }

                simulationYear++;
                Console.Clear();
            }
            
        }
    }
}