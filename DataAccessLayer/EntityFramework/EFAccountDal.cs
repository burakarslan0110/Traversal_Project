using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFAccountDal : GenericUOWRepository<Account>, IAccountDal
    {
        public EFAccountDal(Context context) : base(context)
        {
            
        }

        public List<Account> GetAccountWithGuide()
        {
            using (var c = new Context())
            {
                return c.Accounts.Include(x => x.Guide).ToList();

            }
        }

       
    }
}
