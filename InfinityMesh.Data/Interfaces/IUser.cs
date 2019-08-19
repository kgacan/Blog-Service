using InfinityMesh.Data.Data.Model;
using Microsoft.AspNetCore.Identity;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityMesh.Data.Interfaces
{
    public interface IUser
    {
        IQueryable<AppUser> GetAll(string keyword);
        Task<AppUser> GetById(string id);
        int GetNumberOfBlogs(string id);
    }
}
