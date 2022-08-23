namespace Services.Services
{
    public class StudentService : IStudentService
    {
        public StudentService(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public string ConnectionString { get; }

        public bool Delete(int id)
        {
            using IDbConnection connection = new SqlConnection(ConnectionString);
            return connection.Delete(new Student { Id = id });
        }

        public List<Student> GetAll()
        {
            using IDbConnection connection = new SqlConnection(ConnectionString);
            return connection.GetAll<Student>().ToList();
        }

        public Student GetById(int id)
        {
            using IDbConnection connection = new SqlConnection(ConnectionString);
            return connection.Get<Student>(id);
        }

        public int Insert(Student student)
        {
            using IDbConnection connection = new SqlConnection(ConnectionString);
            int id = Convert.ToInt32(connection.Insert(student));
            return id;
        }

        public bool Update(Student student)
        {
            using IDbConnection connection = new SqlConnection(ConnectionString);
            return connection.Update(student);
        }
    }
}
