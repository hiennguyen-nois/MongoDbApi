using API.Data;
using API.Entities.Test;

namespace API.Repos
{
    public class TestRepository : BaseRepository<Tests>, ITestRepository
    {
        private readonly IDataContext _context;

        public TestRepository(IDataContext context) : base("Tests", context)
        {
            _context = context;
        }
    }
}
