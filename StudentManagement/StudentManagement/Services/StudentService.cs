using StudentManagement.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace StudentManagement.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMongoCollection<Student> _students;
        private readonly IMongoCollection<Course> _courses;

        public StudentService(IStudentStoreDatabaseSettings settings, IMongoClient mongoclient)
        {
            var database = mongoclient.GetDatabase(settings.DatabaseName);
            _students = database.GetCollection<Student>(settings.StudentCoursesCollectionName);
            _courses = database.GetCollection<Course>(settings.CoursesCollectionName);
        }
        public Student Create(Student Student)
        {
            
            _students.InsertOne(Student);
            return Student;
        }

        public List<Student> Get()
        {
            return _students.Find(StudentService => true).ToList();
        }

        public Student Get(string id)
        {
            return _students.Find(student => student.Id == id) .FirstOrDefault();

        }

        public void remove(string id)
        {
            _students.DeleteOne(student => student.Id == id);
        }

        public void Update(string id, Student Student)
        {
            _students.ReplaceOne(Student => Student.Id == id, Student);
        }
        public List<Course> GetCourses()
        {
            return _courses.Find(StudentService => true).ToList();
        }

        public void CreateCourse(Course course)
        {
            _courses.InsertOne(course);
        }

        public void UpdateCourse(string id, Course course)
        {
            var filter = Builders<Course>.Filter.Eq("_id", ObjectId.Parse(id));
            var update = Builders<Course>.Update.Set("CourseName", course.CourseName);

            _courses.UpdateOne(filter, update);
        }


    }
}
