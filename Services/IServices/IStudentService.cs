namespace Services.IServices
{
    public interface IStudentService
    {
        List<Student> GetAll();
        Student GetById(int id);
        int Insert(Student student);
        bool Update(Student student);
        bool Delete(int id);
    }
}
