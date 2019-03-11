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
        public class RolesController : ControllerBase
        {
            private IRoleRepository roleRepo;

            public RolesController(IRoleRepository roleRepo)
            {
                this.roleRepo = roleRepo;
            }
        // GET: api/Roles
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Roles>))]
        public ActionResult<IEnumerable<Roles>> Get()
        {

            return Ok(roleRepo.Retrieve().ToList());
        }

        // GET: api/Role/5
        [HttpGet("{id}", Name = "GetRoleByID")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Roles))]
        public async Task<ActionResult<Roles>> Get(Guid id)
        {
            try
            {
                var result = await roleRepo.RetrieveAsync(id);
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

        // GET: api/Roles/5
        [HttpGet("{page}/{itemsPerPage}", Name = "GetRolesWithPagination")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(PaginationResult<Roles>))]

        public async Task<ActionResult<PaginationResult<Roles>>> Get(int page, int itemsPerPage, string filter)
        {
            try
            {
                var result = new PaginationResult<Roles>();
                result = roleRepo.RetrieveRolesWithPagination(page, itemsPerPage, filter);
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
            [ProducesResponseType(201, Type = typeof(Roles))]
            public async Task<ActionResult<Roles>> Post([FromBody] Roles role)
            {
                try
                {
                    role.RoleID = Guid.NewGuid();
                    await roleRepo.CreateAsync(role);
                    return CreatedAtRoute("GetRoleByID",
                        new
                        {
                            id = role.RoleID
                        },
                        role);

                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }

            // PUT: api/Roles/5
            [HttpPut("{id}")]
            [ProducesResponseType(404)]
            [ProducesResponseType(400)]
            [ProducesResponseType(200, Type = typeof(Roles))]
            public async Task<ActionResult<Roles>> Put(Guid id, [FromBody] Roles role)
            {
                try
                {
                    var result = roleRepo.Retrieve().FirstOrDefault(x => x.RoleID == id);
                    if (result == null)
                    {
                        return NotFound();
                    }
                    await roleRepo.UpdateAsync(id, role);

                    return Ok(role);

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
                    var result = roleRepo.Retrieve().FirstOrDefault(x => x.RoleID == id);
                    if (result == null)
                    {
                        return NotFound();
                    }

                    await roleRepo.DeleteAsync(id);
                    return NoContent();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
        }
    }
