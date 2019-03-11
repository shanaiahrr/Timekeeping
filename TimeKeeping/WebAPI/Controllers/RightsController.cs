using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [EnableCors("TimeTrackingAngular")]
    [Route("api/[controller]")]
    [ApiController]
    public class RightsController : ControllerBase
    {
        private IRightRepository rightRepo;

        public RightsController(IRightRepository rightRepo)
        {
            this.rightRepo = rightRepo;
        }
        // GET: api/Rights
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Rights>))]
        public ActionResult<IEnumerable<Rights>> Get()
        {

            return Ok(rightRepo.Retrieve().ToList());
        }

        // GET: api/Rights/5
        [HttpGet("{id}", Name = "GetRightByID")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Rights))]
        public async Task<ActionResult<Rights>> Get(Guid id)
        {
            try
            {
                var result = await rightRepo.RetrieveAsync(id);
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

        // GET: api/Rights/5
        [HttpGet("{page}/{itemsPerPage}", Name = "GetRightsWithPagination")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(PaginationResult<Rights>))]

        public async Task<ActionResult<PaginationResult<Rights>>> Get(int page, int itemsPerPage, string filter)
        {
            try
            {
                var result = new PaginationResult<Rights>();
                result = rightRepo.RetrieveRightsWithPagination(page, itemsPerPage, filter);
                return result;

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        // POST: api/Rights
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201, Type = typeof(Rights))]
        public async Task<ActionResult<Rights>> Post([FromBody] Rights right)
        {
            try
            {
                right.RightID = Guid.NewGuid();
                await rightRepo.CreateAsync(right);
                return CreatedAtRoute("GetRightByID",
                    new
                    {
                        id = right.RightID
                    },
                    right);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Rights/5
        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Rights))]
        public async Task<ActionResult<Rights>> Put(Guid id, [FromBody] Rights right)
        {
            try
            {
                var result = rightRepo.Retrieve().FirstOrDefault(x => x.RightID == id);
                if (result == null)
                {
                    return NotFound();
                }
                await rightRepo.UpdateAsync(id, right);

                return Ok(right);

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
                var result = rightRepo.Retrieve().FirstOrDefault(x => x.RightID == id);
                if (result == null)
                {
                    return NotFound();
                }

                await rightRepo.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
