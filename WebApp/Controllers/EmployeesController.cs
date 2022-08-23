namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public EmployeesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var employees = unitOfWork.EmployeeService.GetAll().ToList();
                if (employees == null)
                {
                    throw new NullReferenceException();
                }
                return Ok(employees);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetAllWithCompany")]
        public IActionResult GetAllWithCompany()
        {
            try
            {
                var employees = unitOfWork.EmployeeService.GetAllWithCompany().ToList();
                if (employees == null)
                {
                    throw new NullReferenceException();
                }
                return Ok(employees);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("Find/{id:int}")]
        public IActionResult Find(int id)
        {
            try
            {
                var employee = unitOfWork.EmployeeService.Find(id);
                if (employee == null)
                {
                    throw new NullReferenceException();
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("FindWithCompany/{id:int}")]
        public IActionResult FindWithCompany(int id)
        {
            try
            {
                var employee = unitOfWork.EmployeeService.FindWithCompany(id);
                if (employee == null)
                {
                    throw new NullReferenceException();
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public IActionResult Create(AddEmployeeDTO employeeDTO)
        {
            try
            {
                var employee = unitOfWork.EmployeeService.Add(employeeDTO);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public IActionResult Edit(EditEmployeeDTO employeeDTO)
        {
            try
            {
                var employee = unitOfWork.EmployeeService.Update(employeeDTO);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                unitOfWork.EmployeeService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
