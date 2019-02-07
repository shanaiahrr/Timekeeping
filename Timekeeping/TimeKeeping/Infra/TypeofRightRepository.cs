using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra
{
    public class TypeofRightRepository : RepositoryBase<TypeofRights>, ITypeofRightRepository
    {
        public TypeofRightRepository(TimeKeepingDBContext context) : base(context)
        {

        }
    
    }
}
