using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra
{
    public class RolesRepository : RepositoryBase<Roles>, IRoleRepository
    {
        public RolesRepository(TimeKeepingDBContext context) : base(context)
        {

        }

        public PaginationResult<Roles> RetrieveRolesWithPagination(int page, int itemsPerPage, string filter)
        {
            PaginationResult<Roles> result = new PaginationResult<Roles>();
            if (string.IsNullOrEmpty(filter))
            {
                result.Results = context.Set<Roles>().OrderBy(x => x.RoleName).Skip(page).Take(itemsPerPage).ToList();

                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Roles>().Count();
                }
            }
            else
            {
                result.Results = context.Set<Roles>()
                  .Where(x => x.RoleName.ToLower().Contains(filter.ToLower()))
                  .OrderBy(x => x.RoleName)
                  .Skip(page)
                  .Take(itemsPerPage).ToList();

                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Roles>()
                        .Where(x => x.RoleName.ToLower().Contains(filter.ToLower()))
                        .Count();
                }
            }

            return result;
        }
    }
}
