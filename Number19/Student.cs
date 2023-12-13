using System;
using System.Collections.Generic;

namespace Number19;

public class Student
{
    public enum GenderType
    {
        Male,
        Female
    }

    private static readonly Random GlobalRandom = new();
    private static readonly NamesData NamesData = new("names.json");
    public string LastName { get; private set; }
    public string FirstName { get; private set; }
    public string PatronymicName { get; private set; }
    public GenderType Gender { get; private set; }
    public DateTime BirthDate { get; private set; }
    public string GroupName { get; private set; }
    public Dictionary<string, int> Grades { get; private set; }
    public int EducationYear { get; private set; }

    public Student(int currentYear)
    {
        Gender = (GenderType)GlobalRandom.Next(2);

        if (Gender == GenderType.Male)
        {
            LastName = NamesData.MaleSurnames[GlobalRandom.Next(NamesData.MaleSurnames.Length)];
            FirstName = NamesData.MaleNames[GlobalRandom.Next(NamesData.MaleNames.Length)];
            PatronymicName = NamesData.MalePatronymics[GlobalRandom.Next(NamesData.MalePatronymics.Length)];
        }
        else
        {
            LastName = NamesData.FemaleSurnames[GlobalRandom.Next(NamesData.FemaleSurnames.Length)];
            FirstName = NamesData.FemaleNames[GlobalRandom.Next(NamesData.FemaleNames.Length)];
            PatronymicName = NamesData.FemalePatronymics[GlobalRandom.Next(NamesData.FemalePatronymics.Length)];
        }

        BirthDate = new DateTime(GlobalRandom.Next(currentYear - 22, currentYear - 16), GlobalRandom.Next(1, 13),
            GlobalRandom.Next(1, 29));

        var currentYearStr = currentYear.ToString().Substring(2);
        switch (GlobalRandom.Next(3))
        {
            case 0:
                GroupName = "БИСТ-" + currentYearStr;
                break;
            case 1:
                GroupName = "БИВТ-" + currentYearStr;
                break;
            case 2:
                GroupName = "БПИ-" + currentYearStr;
                break;
        }

        EducationYear = 1;
        Grades = new Dictionary<string, int>
        {
            { "Математика", GlobalRandom.Next(50, 101) },
            { "Информатика", GlobalRandom.Next(50, 101) },
            { "Русский язык", GlobalRandom.Next(50, 101) }
        };
    }

    public int AdvanceYear()
    {
        if (EducationYear < 4)
            EducationYear++;
        else
            return -1;

        return EducationYear;
    }

    public override string ToString()
    {
        return $"ФИО: {LastName} {FirstName} {PatronymicName}; Группа: {GroupName}";
    }
}