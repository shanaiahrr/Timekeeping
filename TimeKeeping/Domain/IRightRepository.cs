using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IRightRepository : IRepository<Rights>
    {
        PaginationResult<Rights> RetrieveRightsWithPagination(int page, int itemsPerPage, string filter);

} 
    
}
