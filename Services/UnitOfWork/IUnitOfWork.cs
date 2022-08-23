namespace Services.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICompanyService CompanyService { get; }
        IEmployeeService EmployeeService { get; }
        IStudentService StudentService { get; }
        void SaveChanges();
    }
}