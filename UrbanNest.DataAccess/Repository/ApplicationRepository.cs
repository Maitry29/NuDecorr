﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanNest.DataAccess.Data;
using UrbanNest.DataAccess.Repository.IRepository;
using UrbanNest.Models;

namespace UrbanNest.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private ApplicationDbContext _db;
        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(ApplicationUser applicationUser)
        {
            _db.applicationUsers.Update(applicationUser);
        }
    }
}
