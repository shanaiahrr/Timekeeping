
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public interface IRoleRightRepository : IRepository<RoleRights>
    {
        IEnumerable<RoleRights> RetrieveWithRoleId(Guid roleId);

        PaginationResult<RoleRights> RetrieveRoleRightsWithPagination(int page, int itemsPerPage, string filter);

    }

}