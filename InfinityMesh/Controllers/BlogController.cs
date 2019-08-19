using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InfinityMesh.Data.Data.Model;
using InfinityMesh.Data.Interfaces;
using InfinityMesh.ViewModels.Blog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;

namespace InfinityMesh.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        private readonly IBlog _blogService;
        private readonly IMapper _mapper;

        public BlogController(IBlog blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }


        public IActionResult Insert(string id)
        {
            var model = new BlogAddVM
            {
                PublishedDate = DateTime.Now,
                appUserId = id
            };
            return PartialView(model);
        }

        public IActionResult SaveBlog(BlogAddVM input)
        {
            var blog = _mapper.Map<Blog>(input);

            _blogService.Insert(blog);

            return RedirectToAction("Details", "User", new { id = input.appUserId });
        }

        public async Task<IActionResult> Show(string pageIndex, string id, DateTime FromDate, DateTime ToDate)
        {
            var listOfBlogs = _blogService.GetByParametars(id, FromDate, ToDate);

            //var list = _mapper.Map<List<BlogShowVM>>(listOfBlogs);

            var list = listOfBlogs.Select(x => new BlogShowVM
            {
                PublishedDate = x.PublishedDate,
                Summary = x.Summary,
                Title = x.Title
            }).AsNoTracking().OrderBy(x => x.PublishedDate);

            int? page = 1;
            if (pageIndex != null)
                page = Int32.Parse(pageIndex);

            var model = await PagingList.CreateAsync(list, 5, page ?? 1);

            return PartialView(model);
        }
    }
}