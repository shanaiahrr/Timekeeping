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
    public class TypeofRightsController : ControllerBase
    {
        private ITypeofRightRepository typeOfRightRepo;

        public TypeofRightsController(ITypeofRightRepository typeOfRightRepo)
        {
            this.typeOfRightRepo = typeOfRightRepo;
        }
        // GET: api/TypeofRights
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<TypeofRights>))]
        public ActionResult<IEnumerable<TypeofRights>> Get()
        {

            return Ok(typeOfRightRepo.Retrieve().ToList());
        }

        // GET: api/TypeofRights/5
        [HttpGet("{id}", Name = "GetTypeofRightByID")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(TypeofRights))]
        public async Task<ActionResult<TypeofRights>> Get(Guid id)
        {
            try
            {
                var result = await typeOfRightRepo.RetrieveAsync(id);
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


        // POST: api/TypeofRights
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201, Type = typeof(TypeofRights))]
        public async Task<ActionResult<TypeofRights>> Post([FromBody] TypeofRights typeOfRight)
        {
            try
            {
                typeOfRight.Role_TypeID = Guid.NewGuid();
                await typeOfRightRepo.CreateAsync(typeOfRight);
                return CreatedAtRoute("GetTypeOfRightByID",
                    new
                    {
                        id = typeOfRight.Role_TypeID
                    },
                    typeOfRight);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/TypeofRights/5
        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(TypeofRights))]
        public async Task<ActionResult<TypeofRights>> Put(Guid id, [FromBody] TypeofRights typeofRight)
        {
            try
            {
                var result = typeOfRightRepo.Retrieve().FirstOrDefault(x => x.Role_TypeID == id);
                if (result == null)
                {
                    return NotFound();
                }
                await typeOfRightRepo.UpdateAsync(id, typeofRight);

                return Ok(typeofRight);

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
                var result = typeOfRightRepo.Retrieve().FirstOrDefault(x => x.Role_TypeID == id);
                if (result == null)
                {
                    return NotFound();
                }

                await typeOfRightRepo.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
