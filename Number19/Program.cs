using System;
using System.Collections.Generic;
using System.Linq;

namespace Number19;

/// <summary>
/// Выбрать студентов с совпадающими днями рождения.
/// </summary>
internal static class Program
{
    private enum CollectionType
    {
        List = 1,
        Dictionary = 2
    }

    public static void Main()
    {
        int simulationYear = 2020;

        // Выбор типа коллекции для обработки и хранения студентов
        Console.WriteLine("[1] List;\n[2] Dictionary;\nВыберите тип коллекции для обработки студентов: ");
        CollectionType choice = (CollectionType)int.Parse(Console.ReadLine());
        Console.Clear();

        switch (choice)
        {
            case CollectionType.List: // Решение с использованием List

                List<Student> studentsList = SimulateYears(simulationYear); // Симуляция 5 лет обучения
                List<List<Student>> resultList = new();
                Console.Clear();

                // Сортировка по дате рождения
                studentsList.Sort((student1, student2) => student1.BirthDate.CompareTo(student2.BirthDate));

                // Поиск студентов с совпадающими днями рождения
                for (int i = 0; i < studentsList.Count; i++)
                {
                    List<Student> studentsWithSameBirthDate = new();
                    studentsWithSameBirthDate.Add(studentsList[i]);
                    for (int j = i + 1; j < studentsList.Count; j++)
                    {
                        if (studentsList[i].BirthDate == studentsList[j].BirthDate)
                        {
                            studentsWithSameBirthDate.Add(studentsList[j]);
                        }
                    }

                    resultList.Add(studentsWithSameBirthDate);
                    i += studentsWithSameBirthDate.Count - 1;
                }

                // Вывод результатов
                foreach (var students in resultList)
                {
                    if (students.Count > 1)
                    {
                        PrintByDate(students[0].BirthDate, students);
                    }
                }

                break;
            case CollectionType.Dictionary: // Решение с использованием Dictionary

                // Симуляция 5 лет обучения
                Dictionary<Student, DateTime> studentsDictionary = SimulateYears(simulationYear).ToDictionary(student => student, student => student.BirthDate);
                Dictionary<DateTime, List<Student>> resultDictionary = new();
                Console.Clear();

                // Поиск студентов с совпадающими днями рождения
                foreach (var student in studentsDictionary)
                {
                    if (!resultDictionary.ContainsKey(student.Value))
                    {
                        resultDictionary.Add(student.Value, new List<Student>());
                    }

                    resultDictionary[student.Value].Add(student.Key);
                }

                // Сортировка по дате рождения и вывод результатов
                foreach (var students in resultDictionary.OrderBy(pair => pair.Key))
                {
                    if (students.Value.Count > 1)
                    {
                        PrintByDate(students.Key, students.Value);
                    }
                }

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private static List<Student> SimulateYears(int simulationYear, int years = 5)
    {
        List<Student> students = new List<Student>();
        for (int i = 0; i < years; i++)
        {
            Console.Write($"Введите количество поступивших студентов в {simulationYear}-м году: ");
            int n = int.Parse(Console.ReadLine());

            AdvanceStudents(students); // Студенты переходят на следующий курс
            AddNewStudents(n, simulationYear, students); // Добавление новых студентов

            simulationYear++;
        }

        return students;
    }

    private static void AdvanceStudents(IList<Student> students)
    {
        for (int i = 0; i < students.Count; i++)
        {
            if (students[i].AdvanceYear() == -1)
            {
                students.RemoveAt(i);
                i--;
            }
        }
    }

    private static void AddNewStudents(int n, int simulationYear, IList<Student> students)
    {
        for (int j = 0; j < n; j++)
            students.Add(new Student(simulationYear));
    }

    private static void PrintByDate(DateTime birthDate, IEnumerable<Student> students)
    {
        Console.WriteLine($"Студенты с датой рождения {birthDate:dd.MM.yyyy}:");
        foreach (var student in students)
            Console.WriteLine(student);
        Console.WriteLine(new string('-', 50));
    }
}