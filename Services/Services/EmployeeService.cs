namespace Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        public EmployeeService(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public string ConnectionString { get; }

        public IEnumerable<DetailsEmployeeDTO> GetAllWithCompany()
        {
            try
            {
                using IDbConnection connection = new SqlConnection(ConnectionString);
                string query = @"
                                SELECT *
                                FROM Employees e INNER JOIN Companies c
                                ON c.Id = e.CompanyId;
                                ";
                IEnumerable<DetailsEmployeeDTO> employees = connection
                    .Query<DetailsEmployeeDTO, EditCompanyDTO, DetailsEmployeeDTO>(sql: query, map: (employee, company) =>
                    {
                        employee.Company = company;
                        return employee;
                    }, splitOn: "id");
                return employees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<EditEmployeeDTO> GetAll()
        {
            try
            {
                using IDbConnection connection = new SqlConnection(ConnectionString);
                IEnumerable<EditEmployeeDTO> employees = connection
                    .Query<EditEmployeeDTO>(sql: StaticDetails.GetEmployees, commandType: CommandType.StoredProcedure);
                return employees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EditEmployeeDTO Find(int id)
        {
            try
            {
                using IDbConnection connection = new SqlConnection(ConnectionString);
                EditEmployeeDTO employee = connection.Query<EditEmployeeDTO>(sql: StaticDetails.GetEmployee,
                    param: new { id }, commandType: CommandType.StoredProcedure).Single();
                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DetailsEmployeeDTO FindWithCompany(int id)
        {
            try
            {
                using IDbConnection connection = new SqlConnection(ConnectionString);
                string query = @"
                                SELECT *
                                FROM Employees e INNER JOIN Companies c
                                ON c.Id = e.CompanyId
                                WHERE e.Id = @id;
                                ";
                DetailsEmployeeDTO employee = connection.Query<DetailsEmployeeDTO, EditCompanyDTO, DetailsEmployeeDTO>(sql: query,
                    map: (employee, company) =>
                    {
                        employee.Company = company;
                        return employee;
                    }, param: new { id }, splitOn: "id").Single();
                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EditEmployeeDTO Add(AddEmployeeDTO employeeDTO)
        {
            try
            {
                using IDbConnection connection = new SqlConnection(ConnectionString);
                EditEmployeeDTO employee = connection.QuerySingle<EditEmployeeDTO>(StaticDetails.AddEmployee,
                    employeeDTO, commandType: CommandType.StoredProcedure);
                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EditEmployeeDTO Update(EditEmployeeDTO employeeDTO)
        {
            try
            {
                using IDbConnection connection = new SqlConnection(ConnectionString);
                EditEmployeeDTO employee = connection.QuerySingle<EditEmployeeDTO>(StaticDetails.UpdateEmployee,
                    employeeDTO, commandType: CommandType.StoredProcedure);
                return employee;
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
                connection.Execute(sql: StaticDetails.RemoveEmployee, param: new { id }, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
