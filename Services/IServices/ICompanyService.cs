namespace Services.IServices
{
    public interface ICompanyService
    {
        IEnumerable<EditCompanyDTO> GetAll();
        IEnumerable<DetailsCompanyDTO> GetAllWithEmployees();
        EditCompanyDTO Find(int id);
        DetailsCompanyDTO FindWithEmployees(int id);
        EditCompanyDTO Add(AddCompanyDTO company);
        EditCompanyDTO Update(EditCompanyDTO company);
        void Delete(int id);
    }
}
