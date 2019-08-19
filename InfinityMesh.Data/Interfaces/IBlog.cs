using InfinityMesh.Data.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfinityMesh.Data.Interfaces
{
    public interface IBlog
    {
        void Insert(Blog newBlog);
        IOrderedQueryable<Blog> GetByParametars(string Id, DateTime FromDate, DateTime ToDate);
    }
}
