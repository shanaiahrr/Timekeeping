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
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository employeeRepo;

        public EmployeeController(IEmployeeRepository employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }
        // GET: api/Employee
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Employee>))]
        public ActionResult<IEnumerable<Employee>> Get()
        {

            return Ok(employeeRepo.Retrieve().ToList());
        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "GetEmployeeByID")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Employee))]
        public async Task<ActionResult<Employee>> Get(string id)
        {
            try
            {
                var result = await employeeRepo.RetrieveAsync(id);
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

        // GET: api/Employee/5
        [HttpGet("{page}/{itemsPerPage}", Name = "GetEmployeeWithPagination")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(PaginationResult<Employee>))]

        public async Task<ActionResult<PaginationResult<Employee>>> Get(int page, int itemsPerPage, string filter)
        {
            try
            {
                var result = new PaginationResult<Employee>();
                result = employeeRepo.RetrieveEmployeeWithPagination(page, itemsPerPage, filter);
                return result;

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        // POST: api/Employee
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201, Type = typeof(Employee))]
        public async Task<ActionResult<Employee>> Post([FromBody] Employee employee)
        {
            try
            {
                employee.RoleID = new Guid("03EF0911-7415-4A51-B52C-A63380425630");
                await employeeRepo.CreateAsync(employee);
                return CreatedAtRoute("GetEmployeeByID",
                    new
                    {
                        id = employee.EmployeeID
                    },
                    employee);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Employee))]
        public async Task<ActionResult<Employee>> Put(string id, [FromBody] Employee employee)
        {
            try
            {
                var result = employeeRepo.Retrieve().FirstOrDefault(x => x.EmployeeID == id);
                if (result == null)
                {
                    return NotFound();
                }
                await employeeRepo.UpdateAsync(id, employee);

                return Ok(employee);

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var result = employeeRepo.Retrieve().FirstOrDefault(x => x.EmployeeID == id);
                if (result == null)
                {
                    return NotFound();
                }

                await employeeRepo.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
