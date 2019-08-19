using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InfinityMesh.Data.Data.Model
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Summary { get; set; }

        [ForeignKey("appUserId")]
        public string appUserId { get; set; }
        public AppUser appUser { get; set; }
    }
}
