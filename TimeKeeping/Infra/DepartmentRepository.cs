﻿using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra
{
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(TimeKeepingDBContext context) : base(context)
        {

        }

        public PaginationResult<Department> RetrieveDepartmentWithPagination(int page, int itemsPerPage, string filter)
        {
            PaginationResult<Department> result = new PaginationResult<Department>();
            if (string.IsNullOrEmpty(filter))
            {
                result.Results = context.Set<Department>().OrderBy(x => x.DepartmentName).Skip(page).Take(itemsPerPage).ToList();

                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Department>().Count();
                }
            }
            else
            {
                result.Results = context.Set<Department>()
                  .Where(x => x.DepartmentName.ToLower().Contains(filter.ToLower()))
                  .OrderBy(x => x.DepartmentName)
                  .Skip(page)
                  .Take(itemsPerPage).ToList();

                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Department>()
                        .Where(x => x.DepartmentName.ToLower().Contains(filter.ToLower()))
                        .Count();
                }
            }

            return result;
        }
    }
}
