using System;
using System.Collections.Generic;

namespace Number20;
internal static class Program
{
    public static void Main(string[] args)
    {
        int simulationYear = 2020;
        List<Student> students = new List<Student>();
        List<Student> result = new List<Student>();

        // Симуляция 5 лет
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Введите количество поступивших студентов в {simulationYear}-м году: ");
            int n = int.Parse(Console.ReadLine());

            // Перевод студентов на следующий курс
            for (var j = students.Count - 1; j >= 0; j--)
            {
                if (students[j].NextCourse() == -1)
                {
                    students.RemoveAt(j);
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

        List<(string, int)> bistStudents = new List<(string, int)>();
        foreach (var t in students)
        {
            if (t.Group.Contains("БИСТ"))
            {
                bistStudents.Add((t.Name, t.Course));
            }
        }

        foreach (var t in students)
        {
            if (t.Group.Contains("БИВТ") && bistStudents.Contains((t.Name, t.Course)))
            {
                result.Add(t);
            }
        }

        string sep = new string('—', 40);

        Console.WriteLine(sep);
        foreach (var t in result)
        {
            Console.WriteLine($"{t}\n{sep}");
        }
    }
}