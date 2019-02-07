using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra
{
    public class ShiftRepository : RepositoryBase<Shifts>, IShiftRepository
    {
        public ShiftRepository(TimeKeepingDBContext context) : base(context)
        {

        }

        public PaginationResult<Shifts> RetrieveShiftsWithPagination(int page, int itemsPerPage, string filter)
        {
            PaginationResult<Shifts> result = new PaginationResult<Shifts>();
            if (string.IsNullOrEmpty(filter))
            {
                result.Results = context.Set<Shifts>().OrderBy(x => x.Shift_Type).Skip(page).Take(itemsPerPage).ToList();

                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Shifts>().Count();
                }
            }
            else
            {
                result.Results = context.Set<Shifts>()
                  .Where(x => x.Shift_Type.ToLower().Contains(filter.ToLower()))
                  .OrderBy(x => x.Shift_Type)
                  .Skip(page)
                  .Take(itemsPerPage).ToList();

                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Shifts>()
                        .Where(x => x.Shift_Type.ToLower().Contains(filter.ToLower()))
                        .Count();
                }
            }

            return result;
        }
    }
}
