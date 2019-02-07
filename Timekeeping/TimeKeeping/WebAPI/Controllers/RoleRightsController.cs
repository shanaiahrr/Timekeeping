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
    public class RoleRightsController : ControllerBase
    {
        private IRoleRightRepository roleRightRepo;

        public RoleRightsController(IRoleRightRepository roleRightRepo)
        {
            this.roleRightRepo = roleRightRepo;
        }
        // GET: api/RoleRights
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<RoleRights>))]
        public ActionResult<IEnumerable<RoleRights>> Get()
        {

            return Ok(roleRightRepo.Retrieve().ToList());
        }

        // GET: api/RoleRights/5
        [HttpGet("{id}", Name = "GetRoleRightByID")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(RoleRights))]
        public async Task<ActionResult<RoleRights>> Get(Guid id)
        {
            try
            {
                var result = await roleRightRepo.RetrieveAsync(id);
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

        // GET: api/RoleRights/5
        [HttpGet("{page}/{itemsPerPage}", Name = "GetRoleRightsWithPagination")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(PaginationResult<RoleRights>))]

        public async Task<ActionResult<PaginationResult<RoleRights>>> Get(int page, int itemsPerPage, string filter)
        {
            try
            {
                var result = new PaginationResult<RoleRights>();
                result = roleRightRepo.RetrieveRoleRightsWithPagination(page, itemsPerPage, filter);
                return result;

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        // POST: api/Roles
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201, Type = typeof(RoleRights))]
        public async Task<ActionResult<RoleRights>> Post([FromBody] RoleRights roleRight)
        {
            try
            {
                roleRight.Role_RightID = Guid.NewGuid();
                await roleRightRepo.CreateAsync(roleRight);
                return CreatedAtRoute("GetRoleRightByID",
                    new
                    {
                        id = roleRight.Role_RightID
                    },
                    roleRight);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/RoleRights/5
        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(RoleRights))]
        public async Task<ActionResult<RoleRights>> Put(Guid id, [FromBody] RoleRights roleRight)
        {
            try
            {
                var result = roleRightRepo.Retrieve().FirstOrDefault(x => x.Role_RightID == id);
                if (result == null)
                {
                    return NotFound();
                }
                await roleRightRepo.UpdateAsync(id, roleRight);

                return Ok(roleRight);

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
                var result = roleRightRepo.Retrieve().FirstOrDefault(x => x.Role_RightID == id);
                if (result == null)
                {
                    return NotFound();
                }

                await roleRightRepo.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
