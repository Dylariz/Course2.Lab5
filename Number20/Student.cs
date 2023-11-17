using System;
using System.Collections.Generic;
using System.Text;

namespace Number20;
public class Student
{
    public enum Genders
    {
        Male,
        Female
    }
    private static Random _random = new();
    
    private static readonly string[] MaleNames =
    {
        "Александр", "Алексей", "Анатолий", "Андрей", "Антон", "Аркадий", "Борис", "Вадим", "Валентин", "Валерий",
        "Василий", "Виктор", "Виталий", "Владимир", "Владислав", "Геннадий", "Георгий", "Григорий", "Даниил",
        "Денис", "Дмитрий", "Евгений", "Егор", "Иван", "Игорь", "Кирилл", "Константин", "Лев", "Леонид", "Максим",
        "Михаил", "Никита", "Николай", "Олег", "Павел", "Роман", "Сергей", "Станислав", "Тимофей", "Юрий", "Ярослав"
    };
    private static readonly string[] MaleSurnames =
    {
        "Иванов", "Петров", "Сидоров", "Кузнецов", "Смирнов", "Михайлов", "Федоров", "Соколов", "Яковлев", "Попов",
        "Андреев", "Алексеев", "Александров", "Лебедев", "Григорьев", "Степанов", "Николаев", "Орлов", "Козлов",
        "Васильев", "Зайцев", "Павлов", "Семенов", "Голубев", "Виноградов", "Богданов", "Воробьев", "Фролов",
        "Матвеев", "Дмитриев", "Жуков", "Белов", "Комаров", "Осипов", "Киселев", "Тихонов", "Макаров", "Анисимов",
        "Ершов", "Родионов", "Коновалов", "Лазарев", "Абобит"
    };
    private static readonly string[] MalePatronymics =
    {
        "Александрович", "Алексеевич", "Анатольевич", "Андреевич", "Антонович", "Богданович", "Борисович",
        "Вадимович", "Валентинович", "Валерьевич", "Васильевич", "Викторович", "Витальевич", "Владимирович",
        "Владиславович", "Вячеславович", "Геннадьевич", "Георгиевич", "Григорьевич", "Данилович", "Денисович",
        "Дмитриевич", "Евгеньевич", "Егорович", "Иванович", "Игоревич", "Кириллович", "Константинович",
        "Леонидович", "Максимович", "Матвеевич", "Михайлович", "Никитич", "Николаевич", "Олегович", "Павлович",
        "Петрович", "Романович", "Сергеевич", "Станиславович", "Юрьевич"
    };
    private static readonly string[] FemaleNames =
    {
        "Александра", "Алина", "Алла", "Анастасия", "Ангелина", "Анна", "Антонина", "Валентина", "Валерия",
        "Варвара", "Василиса", "Вера", "Вероника", "Виктория", "Галина", "Дарья", "Евгения", "Екатерина", "Елена",
        "Жанна", "Зинаида", "Зоя", "Инга", "Инесса", "Ирина", "Карина", "Кира", "Клавдия", "Кристина", "Лариса",
        "Лидия", "Лилия", "Любовь", "Маргарита", "Марина", "Мария", "Надежда", "Наталья", "Оксана", "Ольга",
        "Светлана", "Татьяна"
    };
    private static readonly string[] FemaleSurnames =
    {
        "Иванова", "Петрова", "Сидорова", "Кузнецова", "Смирнова", "Козлова", "Новикова", "Морозова", "Волкова",
        "Зайцева", "Павлова", "Соловьева", "Васильева", "Попова", "Андреева", "Козлова", "Николаева", "Орлова",
        "Киселева", "Макарова", "Антонова", "Григорьева", "Лебедева", "Соколова", "Князева", "Белова", "Федорова",
        "Тихонова", "Комарова", "Карпова", "Беляева", "Щербакова", "Гущина", "Герасимова", "Медведева", "Дмитриева",
        "Калинина", "Алексеева", "Степанова", "Яковлева", "Сорокина"
    };

    private static readonly string[] FemalePatronymics =
    {
        "Александровна", "Алексеевна", "Анатольевна", "Андреевна", "Антоновна", "Аркадьевна", "Арсеньевна",
        "Богдановна", "Борисовна", "Вадимовна", "Валентиновна", "Валерьевна", "Васильевна", "Викторовна",
        "Витальевна", "Владимировна", "Владиславовна", "Вячеславовна", "Геннадьевна", "Георгиевна", "Григорьевна",
        "Даниловна", "Денисовна", "Дмитриевна", "Евгеньевна", "Егоровна", "Ивановна", "Игоревна", "Ильинична",
        "Кирилловна", "Константиновна", "Леонидовна", "Максимовна", "Матвеевна", "Михайловна", "Николаевна",
        "Олеговна", "Павловна", "Петровна", "Романовна", "Сергеевна"
    };

    public string Surname { get; private set; }
    public string Name { get; private set; }
    public string Patronymic { get; private set; }
    public Genders Gender { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public string Group { get; private set; } // БИСТ-хх, БИВТ-xх, БПИ-xх
    public Dictionary<string, int> Marks { get; private set; }
    public int Course { get; private set; }

    public Student(int simulationYear)
    {
        Gender = (Genders)_random.Next(2);

        if (Gender == Genders.Male)
        {
            Surname = MaleSurnames[_random.Next(MaleSurnames.Length)];
            Name = MaleNames[_random.Next(MaleNames.Length)];
            Patronymic = MalePatronymics[_random.Next(MalePatronymics.Length)];
        }
        else
        {
            Surname = FemaleSurnames[_random.Next(FemaleSurnames.Length)];
            Name = FemaleNames[_random.Next(FemaleNames.Length)];
            Patronymic = FemalePatronymics[_random.Next(FemalePatronymics.Length)];
        }


        DateOfBirth = new DateTime(_random.Next(simulationYear - 22, simulationYear - 16), _random.Next(1, 13),
            _random.Next(1, 29));

        var simulationYearStr = simulationYear.ToString().Substring(2);
        switch (_random.Next(3))
        {
            case 0:
                Group = "БИСТ-" + simulationYearStr;
                break;
            case 1:
                Group = "БИВТ-" + simulationYearStr;
                break;
            case 2:
                Group = "БПИ-" + simulationYearStr;
                break;
        }

        Course = 1;
        Marks = new Dictionary<string, int>
        {
            { "Математика", _random.Next(45, 101) },
            { "Информатика", _random.Next(45, 101) },
            { "Русский язык", _random.Next(45, 101) }
        };
    }

    public int NextCourse()
    {
        if (Course < 4)
        {
            Course++;
        }
        else
        {
            return -1;
        }

        return Course;
    }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append($"ФИО: {Surname} {Name} {Patronymic}\n");
        stringBuilder.Append($"Группа: {Group}");
        return stringBuilder.ToString();
    }
}