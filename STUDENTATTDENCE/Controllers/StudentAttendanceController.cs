using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STUDENTATTDENCE.Model;
using System.Collections.Generic;

namespace STUDENTATTDENCE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAttendanceController : ControllerBase
    {
        DataContext _dataContext = new DataContext();
        // GET: api/<StudentAttendanceController>
        [HttpGet]
        public IEnumerable<StudentAttendanceModel> Get()
        {

            return _dataContext.GetAllStudentAttendanceDetail();
        }



        // GET api/<StudentAttendanceController>/5
        [HttpGet("{id}")]
        public StudentAttendanceModel Get(int id)
        {
            return _dataContext.GetAllStudentAttendanceDetail().FirstOrDefault(x => x.StudentID == id);
        }



        // POST api/<StudentAttendanceController>
        [HttpPost]
        public void Post([FromBody] StudentAttendanceModel sm)
        {
            _dataContext.AddStudentAttendanceDetail(sm);
        }



        // PUT api/<StudentAttendanceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] StudentAttendanceModel sm)
        {
            _dataContext.UpdateStudentAttendanceDetail(id, sm);
        }



        // DELETE api/<StudentAttendanceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _dataContext.DeleteStudentAttendanceDetail(id);
        }
    }
}