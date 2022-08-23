namespace Services.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IConfiguration configuration)
        {
            CompanyService = new CompanyService(configuration);
            EmployeeService = new EmployeeService(configuration);
            StudentService = new StudentService(configuration);
        }

        public ICompanyService CompanyService { get; private set; }
        public IEmployeeService EmployeeService { get; private set; }
        public IStudentService StudentService { get; private set; }

        public void SaveChanges()
        {
            //_context.SaveChanges();
        }

        public void Dispose()
        {
            //_context.Dispose();
        }
    }
}
