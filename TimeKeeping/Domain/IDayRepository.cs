using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IDayRepository : IRepository<Days>
    {
        PaginationResult<Days> RetrieveDaysWithPagination(int page, int itemsPerPage, string filter);

    }


}
