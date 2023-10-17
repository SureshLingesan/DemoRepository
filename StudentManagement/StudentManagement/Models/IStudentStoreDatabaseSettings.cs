namespace StudentManagement.Models
{
    public interface IStudentStoreDatabaseSettings
    {
        public string StudentCoursesCollectionName { get; set; }

        public string CoursesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
