namespace jobs_api.Controllers
{
    using jobs_api.Models;
    using jobs_api.Persistency;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/jobs")]
    public class JobsController : ControllerBase
    {





        // DEPENDENCY INJECTION of the DbContext
        // In a real application, you would typically use a repository pattern

        private readonly JobsDbContext _context;




        // CONSTRUCTOR

        public JobsController(JobsDbContext context)
        {
            _context = context;
        }



        // GET ALL JOBS

        [HttpGet]
        public IActionResult GetAll() 
        {
            // Retrieve all jobs from the database
            // ToList() executes the query and returns the results as a List

            var jobs = _context.Jobs.ToList();
            return Ok(jobs);
        }



        // GET ONE JOB BY ID

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            
            // SingleOrDefault() is an extension method from System.Linq that returns the only element of a sequence that satisfies a specified condition
            // or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition.
            // In this case, we expect IDs to be unique, so we use SingleOrDefault

            var job = _context.Jobs.SingleOrDefault(j => j.Id == id);

            if (job == null)
            {
                return NotFound();
            }
            return Ok();
        }







        // CREATE A NEW JOB

        [HttpPost]
        public IActionResult Post(Job job) 
        {
            return Ok();
            // vamos alterar para create action, seguido de 3 argumentos -> return CreatedAtAction(nameof(GetById), new { id = createdJob.Id }, obj);

        }





        // UPDATE AN EXISTING JOB

        [HttpPut("{id}")]
        public IActionResult Update(int id) 
        {
            return NoContent();
        }





        // DELETE A JOB

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            return NoContent();
        }


    }
}
