using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra
{
    public class RoleRightsRepository : RepositoryBase<RoleRights>, IRoleRightRepository
    {
        public RoleRightsRepository(TimeKeepingDBContext context) : base(context)
        {

        }

        public PaginationResult<Domain.Models.RoleRights> RetrieveRoleRightsWithPagination(int page, int itemsPerPage, string filter)
        {
            PaginationResult<RoleRights> result = new PaginationResult<RoleRights>();
            if (string.IsNullOrEmpty(filter))
            {
                result.Results = context.Set<RoleRights>().OrderBy(x => x.RightID).Skip(page).Take(itemsPerPage).ToList();

                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<RoleRights>().Count();
                }
            }
            else
            {
                result.Results = context.Set<RoleRights>()
                  //.Where(x => x.RightID.Contains(filter.ToLower()))
                  .OrderBy(x => x.RightID)
                  .Skip(page)
                  .Take(itemsPerPage).ToList();

                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Rights>()
                        //.Where(x => x.RightID.ToLower().Contains(filter.ToLower()))
                        .Count();
                }
            }

            return result;
        }

        public IEnumerable<RoleRights> RetrieveWithRoleId(Guid roleId)
        {
            var list = context.Set<RoleRights>().ToList();
            List<RoleRights> tmp = new List<RoleRights>();
                list.ForEach(x =>
            {
                if(x.RoleID == roleId)
                {
                    tmp.Add(x);
                }
            });
            return tmp;
        }
    }
}
