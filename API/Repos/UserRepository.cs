﻿using API.Data;
using API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repos
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        //public UserRepository(IDataContext context)
        //{
        //    _quizCollection = context.DataDb.GetCollection<User>("Users");
        //}

        private readonly IDataContext _context;

        public UserRepository(IDataContext context) : base("Users", context)
        {
            _context = context;
        }


    }
}
