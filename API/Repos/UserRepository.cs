using API.Data;
using API.Entities.User;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repos
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly IDataContext _context;

        public UserRepository(IDataContext context) : base("Users", context)
        {
            _context = context;
        }


    }
}
