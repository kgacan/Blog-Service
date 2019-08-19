using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfinityMesh.ViewModels.Blog
{
    public class BlogAddVM
    {
        public string Title { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Summary { get; set; }
        public string appUserId { get; set; }
    }
}
