using API.Data;
using API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repos
{
    public class QuizRepository : BaseRepository<Quiz>, IQuizRepository
    {
        private readonly IDataContext _context;

        public QuizRepository(IDataContext context) : base("Quizs", context)
        {
            _context = context;
        }


    }
}
