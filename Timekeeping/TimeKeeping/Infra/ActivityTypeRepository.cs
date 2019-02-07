using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra
{
    public class ActivityTypeRepository : RepositoryBase<ActivityType>, IActivityTypeRepository
    {
        public ActivityTypeRepository(TimeKeepingDBContext context) : base(context)
        {

        }

        public PaginationResult<ActivityType> RetrieveActivityTypeWithPagination(int page, int itemsPerPage, string filter)
        {
            PaginationResult<ActivityType> result = new PaginationResult<ActivityType>();
            if (string.IsNullOrEmpty(filter))
            {
                result.Results = context.Set<ActivityType>().OrderBy(x => x.Activity_Type).Skip(page).Take(itemsPerPage).ToList();

                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<ActivityType>().Count();
                }
            }
            else
            {
                result.Results = context.Set<ActivityType>()
                  .Where(x => x.Activity_Type.ToLower().Contains(filter.ToLower()))
                  .OrderBy(x => x.Activity_Type)
                  .Skip(page)
                  .Take(itemsPerPage).ToList();

                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<ActivityType>()
                        .Where(x => x.Activity_Type.ToLower().Contains(filter.ToLower()))
                        .Count();
                }
            }

            return result;
        }
    }
}
