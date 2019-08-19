using InfinityMesh.Data;
using InfinityMesh.Data.Data.Model;
using InfinityMesh.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace InfinityMesh.Service
{
    public class BlogService : IBlog
    {
        private readonly ApplicationDbContext _db;
        public BlogService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IOrderedQueryable<Blog> GetByParametars(string Id, DateTime FromDate, DateTime ToDate)
        {
            var query = _db.Blogs.Where(x => x.appUserId == Id).AsQueryable();

            query = query.Where(x => x.PublishedDate >= FromDate);

            int value = DateTime.Compare(ToDate, DateTime.Now.AddYears(-100));

            if (value > 0)
            {
                DateTime NewToDate = ToDate.AddDays(1);
                query = query.Where(x => x.PublishedDate <= NewToDate);
            }
                
            var list = query.AsNoTracking().OrderBy(x=>x.PublishedDate);

            return list;
        }

        public void Insert(Blog newBlog)
        {
            _db.Blogs.Add(newBlog);
            _db.SaveChanges();
        }
    }
}
