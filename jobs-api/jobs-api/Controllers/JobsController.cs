namespace jobs_api.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/jobs")]
    public class JobsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll() 
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Create() 
        {
            return Ok();
            // vamos alterar para create action, seguido de 3 argumentos -> return CreatedAtAction(nameof(GetById), new { id = createdJob.Id }, obj);

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id) 
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            return NoContent();
        }


    }
}
