using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(TimeKeepingDBContext context) : base(context)
        {

        }

        public PaginationResult<Employee> RetrieveEmployeeWithPagination(int page, int itemsPerPage, string filter)
        {
            PaginationResult<Employee> result = new PaginationResult<Employee>();
            if (string.IsNullOrEmpty(filter))
            {
                result.Results = context.Set<Employee>().OrderBy(x => x.LastName).Skip(page).Take(itemsPerPage).ToList();

                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Employee>().Count();
                }
            }
            else
            {
                result.Results = context.Set<Employee>()
                  .Where(x => x.LastName.ToLower().Contains(filter.ToLower()))
                  .OrderBy(x => x.LastName)
                  .Skip(page)
                  .Take(itemsPerPage).ToList();

                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Employee>()
                         .Where(x => x.FirstName.ToLower().Contains(filter.ToLower()) || x.LastName.ToLower().Contains(filter.ToLower())
                  || x.FullName.ToLower().Contains(filter.ToLower())).Count();
                }
            }

            return result;
        }
    }
}