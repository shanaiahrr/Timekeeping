using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra
{
    public class DaysRepository : RepositoryBase<Days>, IDayRepository
    {
        public DaysRepository(TimeKeepingDBContext context) : base(context)
        {
            
        }

        public PaginationResult<Days> RetrieveDaysWithPagination(int page, int itemsPerPage, string filter)
        {
            PaginationResult<Days> result = new PaginationResult<Days>();
            if (string.IsNullOrEmpty(filter))
            {
                result.Results = context.Set<Days>().OrderBy(x => x.Day).Skip(page).Take(itemsPerPage).ToList();

                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Days>().Count();
                }
            }
            else
            {
                result.Results = context.Set<Days>()
                  .Where(x => x.Day.ToLower().Contains(filter.ToLower()))
                  .OrderBy(x => x.Day)
                  .Skip(page)
                  .Take(itemsPerPage).ToList();

                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Days>()
                        .Where(x => x.Day.ToLower().Contains(filter.ToLower()))
                        .Count();
                }
            }

            return result;
        }
    }
}
