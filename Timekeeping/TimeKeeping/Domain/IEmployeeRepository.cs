using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IEmployeeRepository : IRepository<Employee>
        {
            PaginationResult<Employee> RetrieveEmployeeWithPagination(int page, int itemsPerPage, string filter);
            
        }
    
}
