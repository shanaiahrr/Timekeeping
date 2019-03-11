using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IRoleRepository: IRepository<Roles>
    {
        PaginationResult<Roles> RetrieveRolesWithPagination(int page, int itemsPerPage, string filter);

    }
  
}
