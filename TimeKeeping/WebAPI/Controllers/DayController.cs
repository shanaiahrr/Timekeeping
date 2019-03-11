using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [EnableCors("TimeTrackingAngular")]
    [Route("api/[controller]")]
    [ApiController]
    public class DayController : Controller
    {
        private IDayRepository dayRepo;

        public DayController(IDayRepository dayRepo)
        {
            this.dayRepo = dayRepo;
        }
        // GET: api/Days
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Days>))]
        public ActionResult<IEnumerable<Days>> Get()
        {

            return Ok(dayRepo.Retrieve().ToList());
        }

        // GET: api/Day/5
        [HttpGet("{id}", Name = "GetDayByID")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Days))]
        public async Task<ActionResult<Days>> Get(Guid id)
        {
            try
            {
                var result = await dayRepo.RetrieveAsync(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/Days/5
        [HttpGet("{page}/{itemsPerPage}", Name = "GetDaysWithPagination")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(PaginationResult<Days>))]

        public async Task<ActionResult<PaginationResult<Days>>> Get(int page, int itemsPerPage, string filter)
        {
            try
            {
                var result = new PaginationResult<Days>();
                result = dayRepo.RetrieveDaysWithPagination(page, itemsPerPage, filter);
                return result;

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: api/Day
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201, Type = typeof(Days))]
        public async Task<ActionResult<Days>> Post([FromBody] Days day)
        {
            try
            {
                day.DayID = Guid.NewGuid();
                await dayRepo.CreateAsync(day);
                return CreatedAtRoute("GetDayByID",
                    new
                    {
                        id = day.DayID
                    },
                    day);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Day/5
        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Days))]
        public async Task<ActionResult<Days>> Put(Guid id, [FromBody] Days day)
        {
            try
            {
                var result = dayRepo.Retrieve().FirstOrDefault(x => x.DayID == id);
                if (result == null)
                {
                    return NotFound();
                }
                await dayRepo.UpdateAsync(id, day);

                return Ok(day);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var result = dayRepo.Retrieve().FirstOrDefault(x => x.DayID == id);
                if (result == null)
                {
                    return NotFound();
                }

                await dayRepo.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
