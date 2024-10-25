using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentAdmissionManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAdmissionController : ControllerBase
    {
        // In-memory data store for simplicity
        private static readonly List<StudentAdmissionDetailsModel> _admissionRecords = new List<StudentAdmissionDetailsModel>
        {
            new StudentAdmissionDetailsModel { StudentID = 1, StudentName = "David", StudentClass = "X", DateofJoining = DateTime.Now },
            new StudentAdmissionDetailsModel { StudentID = 2, StudentName = "Villa", StudentClass = "IX", DateofJoining = DateTime.Now }
        };

        // GET: api/studentadmission
        [HttpGet]
        public ActionResult<IEnumerable<StudentAdmissionDetailsModel>> Get()
        {
            return Ok(_admissionRecords);
        }

        // GET: api/studentadmission/5
        [HttpGet("{id}")]
        public ActionResult<StudentAdmissionDetailsModel> Get(int id)
        {
            var admissionRecord = _admissionRecords.FirstOrDefault(x => x.StudentID == id);
            if (admissionRecord == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }
            return Ok(admissionRecord);
        }

        // POST: api/studentadmission
        [HttpPost]
        public ActionResult Post([FromBody] StudentAdmissionDetailsModel newRecord)
        {
            if (newRecord == null || string.IsNullOrEmpty(newRecord.StudentName))
            {
                return BadRequest("Invalid admission record.");
            }

            newRecord.StudentID = _admissionRecords.Count > 0 ? _admissionRecords.Max(x => x.StudentID) + 1 : 1;
            _admissionRecords.Add(newRecord);
            return CreatedAtAction(nameof(Get), new { id = newRecord.StudentID }, newRecord);
        }

        // PUT: api/studentadmission/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] StudentAdmissionDetailsModel updatedRecord)
        {
            if (updatedRecord == null || string.IsNullOrEmpty(updatedRecord.StudentName))
            {
                return BadRequest("Invalid admission record.");
            }

            var existingRecord = _admissionRecords.FirstOrDefault(x => x.StudentID == id);
            if (existingRecord == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }

            existingRecord.StudentName = updatedRecord.StudentName;
            existingRecord.StudentClass = updatedRecord.StudentClass;
            existingRecord.DateofJoining = updatedRecord.DateofJoining;

            return NoContent(); // 204 No Content
        }

        // DELETE: api/studentadmission/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingRecord = _admissionRecords.FirstOrDefault(x => x.StudentID == id);
            if (existingRecord == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }

            _admissionRecords.Remove(existingRecord);
            return NoContent(); // 204 No Content
        }
    }
}
