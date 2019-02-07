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
    public class ShiftsController : ControllerBase
    {
        private IShiftRepository shiftRepo;

        public ShiftsController(IShiftRepository shiftRepo)
        {
            this.shiftRepo = shiftRepo;
        }
        // GET: api/Shift
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Shifts>))]
        public ActionResult<IEnumerable<Shifts>> Get()
        {

            return Ok(shiftRepo.Retrieve().ToList());
        }

        // GET: api/Shift/5
        [HttpGet("{id}", Name = "GetShiftByID")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Shifts))]
        public async Task<ActionResult<Shifts>> Get(Guid id)
        {
            try
            {
                var result = await shiftRepo.RetrieveAsync(id);
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

        // GET: api/Shift/5
        [HttpGet("{page}/{itemsPerPage}", Name = "GetShiftsWithPagination")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(PaginationResult<Shifts>))]

        public async Task<ActionResult<PaginationResult<Shifts>>> Get(int page, int itemsPerPage, string filter)
        {
            try
            {
                var result = new PaginationResult<Shifts>();
                result = shiftRepo.RetrieveShiftsWithPagination(page, itemsPerPage, filter);
                return result;

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        // POST: api/Shift
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201, Type = typeof(Shifts))]
        public async Task<ActionResult<Shifts>> Post([FromBody] Shifts shift)
        {
            try
            {
                shift.ShiftID = Guid.NewGuid();
                await shiftRepo.CreateAsync(shift);
                return CreatedAtRoute("GetDepartmentByID",
                    new
                    {
                        id = shift.ShiftID
                    },
                    shift);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Shift/5
        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Shifts))]
        public async Task<ActionResult<Shifts>> Put(Guid id, [FromBody] Shifts shift)
        {
            try
            {
                var result = shiftRepo.Retrieve().FirstOrDefault(x => x.ShiftID == id);
                if (result == null)
                {
                    return NotFound();
                }
                await shiftRepo.UpdateAsync(id, shift);

                return Ok(shift);

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
                var result = shiftRepo.Retrieve().FirstOrDefault(x => x.ShiftID == id);
                if (result == null)
                {
                    return NotFound();
                }

                await shiftRepo.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
