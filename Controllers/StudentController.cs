using ASPCoreWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly myDbContext dbContext;

        public StudentController(myDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
 /********************************** Get all Students *******************************************/

        [HttpGet]
        public async Task<ActionResult<List<Student>>> getStudent()
        {
            var data = await dbContext.Students.ToListAsync();
            return Ok(data);
         }

 /********************************** Get Student By Id *******************************************/
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> getStudentById(int id)
        {
            var student = await dbContext.Students.FindAsync(id);
            if (student == null){ 
            return NotFound();
            }
            return Ok(student);
        }
 /********************************** create Student *******************************************/

        [HttpPost]
        public async Task<ActionResult<Student>> createStudent(Student std)
        {
            await dbContext.Students.AddAsync(std);
            await dbContext.SaveChangesAsync();
            return Ok(std);
        }

/********************************** Upadte Student *******************************************/
        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> updateStudent(int id ,Student std)
        {
            if (id != std.Id) {
                return BadRequest();
            }
            dbContext.Entry(std).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return Ok(std);
        }

/********************************** Delete Student *******************************************/
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> deleteStudent(int id)
        {
            var std = await dbContext.Students.FindAsync(id);
            if (std == null)
            {
                return NotFound();
            }
             dbContext.Students.Remove(std);
            await dbContext.SaveChangesAsync();
            return Ok(std);

        }
    }
}
