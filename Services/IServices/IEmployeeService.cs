namespace Services.IServices
{
    public interface IEmployeeService
    {
        IEnumerable<EditEmployeeDTO> GetAll();
        IEnumerable<DetailsEmployeeDTO> GetAllWithCompany();
        EditEmployeeDTO Find(int id);
        DetailsEmployeeDTO FindWithCompany(int id);
        EditEmployeeDTO Add(AddEmployeeDTO employee);
        EditEmployeeDTO Update(EditEmployeeDTO employee);
        void Delete(int id);
    }
}
