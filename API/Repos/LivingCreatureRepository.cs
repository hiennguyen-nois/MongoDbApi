using API.Data;
using API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repos
{
    public class LivingCreatureRepository : Repository<LivingCreature>, ILivingCreatureRepository
    {
        private readonly IMyWorldContext _context;

        public LivingCreatureRepository(IOptions<AppSettings> options, IMyWorldContext context) : base(options, context)
        {
            _context = context;
        }

    }
}
