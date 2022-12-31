using Employee.Domain.IRepository;
using Employee.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.DAL.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DbSet<User> _db;
        public UserRepository(StoreContext context) : base(context)
        {
            _db = context.Set<User>();
        }

        public User GetByUserName(string userName)
        {
            return  _db.FirstOrDefault(x=> x.UserName == userName);
        }


    }
}
