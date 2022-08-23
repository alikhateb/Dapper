namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public CompaniesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                List<EditCompanyDTO> companies = unitOfWork.CompanyService.GetAll().ToList();
                if (companies == null)
                {
                    throw new NullReferenceException();
                }
                return Ok(companies);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetWithEmployees")]
        public IActionResult GetAllWithEmployees()
        {
            try
            {
                List<DetailsCompanyDTO> companies = unitOfWork.CompanyService.GetAllWithEmployees().ToList();
                if (companies == null)
                {
                    throw new NullReferenceException();
                }
                return Ok(companies);
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
                EditCompanyDTO company = unitOfWork.CompanyService.Find(id);
                if (company == null)
                {
                    throw new NullReferenceException();
                }
                return Ok(company);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("FindWithEmployees/{id:int}")]
        public IActionResult FindWithEmployees(int id)
        {
            try
            {
                DetailsCompanyDTO company = unitOfWork.CompanyService.FindWithEmployees(id);
                if (company == null)
                {
                    throw new NullReferenceException();
                }
                return Ok(company);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public IActionResult Create(AddCompanyDTO companyDTO)
        {
            try
            {
                EditCompanyDTO company = unitOfWork.CompanyService.Add(companyDTO);
                return Ok(company);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public IActionResult Edit(EditCompanyDTO companyDTO)
        {
            try
            {
                EditCompanyDTO company = unitOfWork.CompanyService.Update(companyDTO);
                return Ok(company);
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
                unitOfWork.CompanyService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
