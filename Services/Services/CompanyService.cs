namespace Services.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IDbConnection connection;
        public CompanyService(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public string ConnectionString { get; }

        public IEnumerable<EditCompanyDTO> GetAll()
        {
            using IDbConnection connection = new SqlConnection(ConnectionString);
            IEnumerable<EditCompanyDTO> companies = connection
                .Query<EditCompanyDTO>(StaticDetails.GetCompanies, commandType: CommandType.StoredProcedure);
            return companies;
        }

        public IEnumerable<DetailsCompanyDTO> GetAllWithEmployees()
        {
            try
            {
                using IDbConnection connection = new SqlConnection(ConnectionString);
                string query = @"
                                select * 
                                from companies c inner join employees e
                                on c.id = e.companyid;
                                ";
                IEnumerable<DetailsCompanyDTO> companies = connection
                    .Query<DetailsCompanyDTO, EditEmployeeDTO, DetailsCompanyDTO>(query, map: (company, employee) =>
                    {
                        company.Employees.Add(employee);
                        return company;
                    }, splitOn: "id");

                var finalResult = companies.GroupBy(c => c.Id).Select(g =>
                {
                    var groupedCompany = g.First();
                    groupedCompany.Employees = g.Select(c => c.Employees.Single()).ToList();
                    return groupedCompany;
                });

                return finalResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EditCompanyDTO Find(int id)
        {
            try
            {
                using IDbConnection connection = new SqlConnection(ConnectionString);
                EditCompanyDTO company = connection.QuerySingle<EditCompanyDTO>(StaticDetails.GetCompany, new { id }, commandType: CommandType.StoredProcedure);
                return company;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DetailsCompanyDTO FindWithEmployees(int id)
        {
            try
            {
                using IDbConnection connection = new SqlConnection(ConnectionString);
                string query = @"
                                select * 
                                from companies c inner join employees e
                                on c.id = e.companyid
                                where c.id = @id;
                                ";
                var company = connection.Query<DetailsCompanyDTO, EditEmployeeDTO, DetailsCompanyDTO>(query, map: (company, employee) =>
                {
                    company.Employees.Add(employee);
                    return company;
                }, splitOn: "id", param: new { id });

                var finalResult = company.GroupBy(c => c.Id).Select(g =>
                {
                    var groupedCompany = g.First();
                    groupedCompany.Employees = g.Select(c => c.Employees.Single()).ToList();
                    return groupedCompany;
                }).Single();

                return finalResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EditCompanyDTO Add(AddCompanyDTO companyDTO)
        {
            try
            {
                using IDbConnection connection = new SqlConnection(ConnectionString);
                EditCompanyDTO company = connection.QuerySingle<EditCompanyDTO>(StaticDetails.AddCompany, param: companyDTO, commandType: CommandType.StoredProcedure);
                return company;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EditCompanyDTO Update(EditCompanyDTO companyDTO)
        {
            try
            {
                using IDbConnection connection = new SqlConnection(ConnectionString);
                EditCompanyDTO company = connection.QuerySingle<EditCompanyDTO>(StaticDetails.UpdateCompany, companyDTO, commandType: CommandType.StoredProcedure);
                return company;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                using IDbConnection connection = new SqlConnection(ConnectionString);
                connection.Execute(sql: StaticDetails.RemoveCompany, param: new { id }, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
