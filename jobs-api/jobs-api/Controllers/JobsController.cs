namespace jobs_api.Controllers
{
    using jobs_api.Models;
    using jobs_api.Persistency;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/jobs")]
    public class JobsController : ControllerBase
    {

        private readonly JobsDbContext _context;

        public JobsController(JobsDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetAll() 
        {
            // ToList() executes the query and returns the results as a List

            var jobs = _context.Jobs.ToList();
            return Ok(jobs);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            // We expect IDs to be unique, so we use SingleOrDefault

            var job = _context.Jobs.SingleOrDefault(j => j.Id == id);

            if (job == null)
            {
                return NotFound();
            }
            return Ok(job);
        }



        [HttpPost]
        public IActionResult Post(Job job) 
        {
            _context.Jobs.Add(job);
            _context.SaveChanges();


            // Returns a 201 Created response with a Location header pointing to the newly created resource

            return CreatedAtAction(nameof(GetById), new { id = job.Id }, job);

        }



        [HttpPut("{id}")]
        public IActionResult Put(int id, Job input) 
        {
            var job = _context.Jobs.SingleOrDefault(j => j.Id == id);

            if (job == null)
            {
                return NotFound();
            }

            // Use the Update method defined in the Job model to update the job details
            job.Update(input.Title, input.Description, input.Company, input.Location, input.Salary);

            // Mark the entity as modified
            _context.Jobs.Update(job);
            _context.SaveChanges();

            return NoContent();

        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, Job input) 
        {
            var job = _context.Jobs.SingleOrDefault(j => j.Id == id);

            if (job == null)
            {
                return NotFound();
            }
            _context.Jobs.Remove(job);
            _context.SaveChanges();

            return NoContent();
        }


    }
}
