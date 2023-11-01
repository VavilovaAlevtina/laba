using DataAccess;

namespace laba
{
    class Program
    {
        static void PrintStudents(University university)
        {
            foreach (Student student in university.Students)
            {
                Console.WriteLine($"Имя: {student.Name}, Фамилия: {student.Surname}, Возраст: {student.Age}, Средняя оценка: {student.AverageMark}");
            }
        }

        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student("Иван", "Иванов", 18, 4),
                new Student("Петр", "Петров", 19, 3),
                new Student("Сидор", "Сидоров", 20, 5),
            };

            University university = new University("Московский Политех", students);
            PrintStudents(university);
            Console.WriteLine();

            Student student = university.FindStudent("Иван", "Иванов");
            university.RemoveStudent("Иван", "Иванов");

            StudentsRepository studentsRepository = new StudentsRepository(new List<University> { university });
            studentsRepository.SaveStudentsToFile("students.txt", "Московский Политех");

            University newUniversity = new University("МГУ", new List<Student>());
            studentsRepository.AddUniversity(newUniversity);
            studentsRepository.LoadStudentsFromFile("students.txt", "МГУ");
            newUniversity.AddStudent(student);
            PrintStudents(newUniversity);
        }
    }
}