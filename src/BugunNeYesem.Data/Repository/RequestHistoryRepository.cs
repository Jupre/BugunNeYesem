using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugunNeYesem.Data.Entity;

namespace BugunNeYesem.Data.Repository
{
    public class RequestHistoryRepository : Repository<RequestHistory>
    {
          public RequestHistoryRepository(BugunNeYesemDbContext context) : base(context)
        { }
    }
}
