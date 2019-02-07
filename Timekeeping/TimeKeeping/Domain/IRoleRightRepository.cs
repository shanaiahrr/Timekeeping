
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IRoleRightRepository : IRepository<RoleRights>
    {
        PaginationResult<RoleRights> RetrieveRoleRightsWithPagination(int page, int itemsPerPage, string filter);

    }

}