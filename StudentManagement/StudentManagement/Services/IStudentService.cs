using StudentManagement.Models;
namespace StudentManagement.Services
{
    public interface IStudentService
    {
        List<Student> Get();
        Student Get(string id);
        Student Create(Student Student);
        void Update(string id, Student Student);
        void remove(string id);

        List<Course> GetCourses();
        void CreateCourse(Course course); // Add this line
        void UpdateCourse(string id, Course course);


    }
}
