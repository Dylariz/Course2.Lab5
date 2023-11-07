using System;
using System.Collections.Generic;

namespace Number20
{
    public class Student
    {
        public enum Genders
        {
            Male,
            Female
        }
        
        private static Random _random = new Random();

        private static readonly string[] Names =
        {
            "Александр", "Алексей", "Анатолий", "Андрей", "Антон", "Аркадий", "Борис", "Вадим", "Валентин", "Валерий",
            "Василий", "Виктор", "Виталий", "Владимир", "Владислав", "Геннадий", "Георгий", "Григорий", "Даниил",
            "Денис", "Дмитрий", "Евгений", "Егор", "Иван", "Игорь", "Кирилл", "Константин", "Лев", "Леонид", "Максим",
            "Михаил", "Никита", "Николай", "Олег", "Павел", "Роман", "Сергей", "Станислав", "Тимофей", "Юрий", "Ярослав"
        };

        private static readonly string[] Surnames =
        {
            "Иванов", "Петров", "Сидоров", "Кузнецов", "Смирнов", "Михайлов", "Федоров", "Соколов", "Яковлев", "Попов",
            "Андреев", "Алексеев", "Александров", "Лебедев", "Григорьев", "Степанов", "Николаев", "Орлов", "Козлов",
            "Васильев", "Зайцев", "Павлов", "Семенов", "Голубев", "Виноградов", "Богданов", "Воробьев", "Фролов",
            "Матвеев", "Дмитриев", "Жуков", "Белов", "Комаров", "Осипов", "Киселев", "Тихонов", "Макаров", "Анисимов",
            "Ершов", "Родионов", "Коновалов", "Лазарев"
        };

        private static readonly string[] Patronymics =
        {
            "Александрович", "Алексеевич", "Анатольевич", "Андреевич", "Антонович", "Богданович", "Борисович",
            "Вадимович", "Валентинович", "Валерьевич", "Васильевич", "Викторович", "Витальевич", "Владимирович",
            "Владиславович", "Вячеславович", "Геннадьевич", "Георгиевич", "Григорьевич", "Данилович", "Денисович",
            "Дмитриевич", "Евгеньевич", "Егорович", "Иванович", "Игоревич", "Кириллович", "Константинович",
            "Леонидович", "Максимович", "Матвеевич", "Михайлович", "Никитич", "Николаевич", "Олегович", "Павлович",
            "Петрович", "Романович", "Сергеевич", "Станиславович", "Юрьевич"
        };

        public string Surname { get; private set; }
        public string Name { get; private set; }
        public string Patronymic { get; private set; }
        public Genders Gender { get; private set; } // True - Мужчина, False - Женщина
        public DateTime DateOfBirth { get; private set; }
        public string Group { get; private set; } // БИСТ-хх, БИВТ-xх, БПИ-xх
        public Dictionary<string, int> Marks { get; private set; }
        public int Course { get; private set; }

        public Student(int simulationYear)
        {
            Surname = Surnames[_random.Next(Surnames.Length)];
            Name = Names[_random.Next(Names.Length)];
            Patronymic = Patronymics[_random.Next(Patronymics.Length)];
            
            Gender = (Genders)_random.Next(2);
            
            DateOfBirth = new DateTime(_random.Next(simulationYear - 22, simulationYear - 16), _random.Next(1, 13),
                _random.Next(1, 29));

            var imulationYearStr = simulationYear.ToString().Substring(2);
            switch (_random.Next(3))
            {
                case 0:
                    Group = "БИСТ-" + imulationYearStr;
                    break;
                case 1:
                    Group = "БИВТ-" + imulationYearStr;
                    break;
                case 2:
                    Group = "БПИ-" + imulationYearStr;
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
    }
}