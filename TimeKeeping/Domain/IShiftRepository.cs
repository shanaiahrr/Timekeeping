using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IShiftRepository : IRepository<Shifts>
    {
        PaginationResult<Shifts> RetrieveShiftsWithPagination(int page, int itemsPerPage, string filter);

    }

}

