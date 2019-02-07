using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra
{
    public class RightsRepository : RepositoryBase<Rights>, IRightRepository
    {
        public RightsRepository(TimeKeepingDBContext context) : base(context)
        {

        }

        public PaginationResult<Rights> RetrieveRightsWithPagination(int page, int itemsPerPage, string filter)
        {
            PaginationResult<Rights> result = new PaginationResult<Rights>();
            if (string.IsNullOrEmpty(filter))
            {
                result.Results = context.Set<Rights>().OrderBy(x => x.NameofRight).Skip(page).Take(itemsPerPage).ToList();

                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Rights>().Count();
                }
            }
            else
            {
                result.Results = context.Set<Rights>()
                  .Where(x => x.NameofRight.ToLower().Contains(filter.ToLower()))
                  .OrderBy(x => x.NameofRight)
                  .Skip(page)
                  .Take(itemsPerPage).ToList();

                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Rights>()
                        .Where(x => x.NameofRight.ToLower().Contains(filter.ToLower()))
                        .Count();
                }
            }

            return result;
        }
    }
}
