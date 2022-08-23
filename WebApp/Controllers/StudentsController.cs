namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public StudentsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var students = unitOfWork.StudentService.GetAll().Select(s => new UpdateStudentDTO
            {
                Id = s.Id,
                Name = s.Name,
                Age = s.Age,
            });
            if (students == null)
            {
                return NotFound();
            }
            return Ok(students);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var student = unitOfWork.StudentService.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            UpdateStudentDTO updateStudentDTO = new UpdateStudentDTO
            {
                Id = student.Id,
                Name = student.Name,
                Age = student.Age,
            };
            return Ok(updateStudentDTO);
        }

        [HttpPost]
        public IActionResult Insert(InsertStudentDTO insertStudentDTO)
        {
            if (insertStudentDTO == null)
            {
                throw new NullReferenceException();
            }
            var student = new Student
            {
                Id = 0,
                Name = insertStudentDTO.Name,
                Age = insertStudentDTO.Age,
            };
            int id = unitOfWork.StudentService.Insert(student);
            student.Id = id;
            return Ok(student);
        }

        [HttpPut]
        public IActionResult Update(UpdateStudentDTO updateStudentDTO)
        {
            if (updateStudentDTO == null)
            {
                throw new NullReferenceException();
            }
            var student = new Student
            {
                Id = updateStudentDTO.Id,
                Name = updateStudentDTO.Name,
                Age = updateStudentDTO.Age,
            };
            unitOfWork.StudentService.Update(student);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var student = unitOfWork.StudentService.GetById(id);
            if (student == null)
            {
                throw new NullReferenceException();
            }
            unitOfWork.StudentService.Delete(id);
            return Ok();
        }
    }
}
