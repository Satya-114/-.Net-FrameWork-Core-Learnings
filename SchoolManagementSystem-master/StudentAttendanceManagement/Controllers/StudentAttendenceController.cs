using Microsoft.AspNetCore.Mvc;

namespace StudentAttendanceManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAttendanceController : ControllerBase
    {
        // In-memory data store for simplicity
        private static readonly List<StudentAttendanceDetailsModel> _attendanceRecords = new List<StudentAttendanceDetailsModel>
        {
            new StudentAttendanceDetailsModel { StudentID = 1, StudentName = "David", AttendencePercentage = 83.25 },
            new StudentAttendanceDetailsModel { StudentID = 2, StudentName = "Villa", AttendencePercentage = 93.23 }
        };

        // GET api/studentattendance
        [HttpGet]
        public ActionResult<IEnumerable<StudentAttendanceDetailsModel>> Get()
        {
            return Ok(_attendanceRecords);
        }

        // GET api/studentattendance/5
        [HttpGet("{id}")]
        public ActionResult<StudentAttendanceDetailsModel> Get(int id)
        {
            var attendanceRecord = _attendanceRecords.FirstOrDefault(x => x.StudentID == id);
            if (attendanceRecord == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }
            return Ok(attendanceRecord);
        }

        // POST api/studentattendance
        [HttpPost]
        public ActionResult Post([FromBody] StudentAttendanceDetailsModel newRecord)
        {
            if (newRecord == null || string.IsNullOrEmpty(newRecord.StudentName))
            {
                return BadRequest("Invalid attendance record.");
            }

            newRecord.StudentID = _attendanceRecords.Count > 0 ? _attendanceRecords.Max(x => x.StudentID) + 1 : 1;
            _attendanceRecords.Add(newRecord);
            return CreatedAtAction(nameof(Get), new { id = newRecord.StudentID }, newRecord);
        }

        // PUT api/studentattendance/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] StudentAttendanceDetailsModel updatedRecord)
        {
            if (updatedRecord == null || string.IsNullOrEmpty(updatedRecord.StudentName))
            {
                return BadRequest("Invalid attendance record.");
            }

            var existingRecord = _attendanceRecords.FirstOrDefault(x => x.StudentID == id);
            if (existingRecord == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }

            existingRecord.StudentName = updatedRecord.StudentName;
            existingRecord.AttendencePercentage = updatedRecord.AttendencePercentage;
            return NoContent(); // 204 No Content
        }

        // DELETE api/studentattendance/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingRecord = _attendanceRecords.FirstOrDefault(x => x.StudentID == id);
            if (existingRecord == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }

            _attendanceRecords.Remove(existingRecord);
            return NoContent(); // 204 No Content
        }
    }
}
