using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STUDENTADMISSION.Model;

namespace STUDENTADMISSION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //Admission
    //https://localhost:7148/api/StudentAdmission
    public class StudentAdmissionController : ControllerBase
    {
        DataContext _dataContext = new DataContext();
        // GET: api/<StudentAttendanceController>
        [HttpGet]
        public IEnumerable<StudentAdmissionDetailsModel> Get()
        {

            return _dataContext.GetAllStudentAdmissionDetailsModel();
        }



        // GET api/<StudentAttendanceController>/5
        [HttpGet("{id}")]
        public StudentAdmissionDetailsModel Get(int id)
        {
            return _dataContext.GetAllStudentAdmissionDetailsModel().FirstOrDefault(x => x.StudentID == id);
        }



        // POST api/<StudentAttendanceController>
        [HttpPost]
        public void Post([FromBody] StudentAdmissionDetailsModel sm)
        {
            _dataContext.AddStudentAdmissionDetailsModel(sm);
        }



        // PUT api/<StudentAttendanceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] StudentAdmissionDetailsModel sm)
        {
            _dataContext.UpdateStudentAdmissionDetailsModel(id, sm);
        }



        // DELETE api/<StudentAttendanceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _dataContext.DeleteStudentAdmissionDetailsModel(id);
        }
    }
}
