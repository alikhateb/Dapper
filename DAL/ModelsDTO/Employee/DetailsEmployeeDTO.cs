namespace DAL.ModelsDTO.Employee
{
    public class DetailsEmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int CompanyId { get; set; }
        public EditCompanyDTO Company { get; set; }
    }
}
