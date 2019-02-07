using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IActivityTypeRepository : IRepository<ActivityType>
    {
        PaginationResult<ActivityType> RetrieveActivityTypeWithPagination(int page, int itemsPerPage, string filter);

    }

}

