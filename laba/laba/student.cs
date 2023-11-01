namespace laba;

public class Student
{
    private string _name;
    private string _surname;
    private int _age;
    private int _avetageMark;

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public string Surname
    {
        get => _surname;
        set => _surname = value;
    }

    public int Age
    {
        get => _age;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Возраст не может быть отрицательным");
            }
            _age = value;
        }
    }

    public int AverageMark
    {
        get => _avetageMark;
        set
        {
            if (value < 0 || value > 5)
            {
                throw new ArgumentException("Средняя оценка не может быть меньше 0 или больше 5");
            }
            _avetageMark = value;
        }
    }

    public Student(string name, string surname, int age, int averageMark)
    {
        _name = name;
        _surname = surname;

        if (age < 0)
        {
            throw new ArgumentException("Возраст не может быть отрицательным");
        }
        _age = age;

        if (averageMark < 0 || averageMark > 5)
        {
            throw new ArgumentException("Средняя оценка не может быть меньше 0 или больше 5");
        }
        _avetageMark = averageMark;
    }
}