namespace DAL.ModelsDTO.Company
{
    public class DetailsCompanyDTO
    {
        public DetailsCompanyDTO()
        {
            Employees = new List<EditEmployeeDTO>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<EditEmployeeDTO> Employees { get; set; }
    }
}
