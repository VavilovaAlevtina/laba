using laba;

namespace DataAccess
{
    public class StudentsRepository
    {
        private List<University> _universities;

        public List<University> Universities => _universities;

        public StudentsRepository(List<University> universities)
        {
            _universities = universities;
        }

        public void AddUniversity(University university)
        {
            Universities.Add(university);
        }

        public void SaveStudentsToFile(string filename, string universityName)
        {
            University university = Universities.Find(university => university.Name == universityName);

            if (university == null)
            {
                throw new ArgumentException("Университет не найден");
            }

            using (StreamWriter sw = new StreamWriter(filename))
            {
                foreach (Student student in university.Students)
                {
                    sw.WriteLine($"{student.Name} {student.Surname} {student.Age} {student.AverageMark}");
                }
            }
        }

        public void LoadStudentsFromFile(string filename, string universityName)
        {
            University university = Universities.Find(university => university.Name == universityName);

            if (university == null)
            {
                throw new ArgumentException("Университет не найден");
            }

            using (StreamReader sr = new StreamReader(filename))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] studentData = line.Split(' ');
                    university.AddStudent(new Student(studentData[0], studentData[1], int.Parse(studentData[2]),
                        int.Parse(studentData[3])));
                }
            }
        }
    }
}