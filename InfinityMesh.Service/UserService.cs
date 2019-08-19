using InfinityMesh.Data;
using InfinityMesh.Data.Data.Model;
using InfinityMesh.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfinityMesh.Service
{
    public class UserService : IUser
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        public UserService(ApplicationDbContext db, UserManager<AppUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IQueryable<AppUser> GetAll(string keyword)
        {
            var query = _userManager.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                if (_userManager.Users.Where(x => x.FirstName.StartsWith(keyword)).Any())
                {
                    query = query.Where(x => x.FirstName.StartsWith(keyword));
                }
                else
                {
                    query = query.Where(x => x.Email.StartsWith(keyword));
                }
            }

            return query;    
        }

        public async Task<AppUser> GetById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            return user;
        }

        public int GetNumberOfBlogs(string id)
        {
            return _db.Blogs.Where(x => x.appUserId == id).Count();
        }
    }
}
