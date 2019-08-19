using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InfinityMesh.Data.Interfaces;
using InfinityMesh.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;

namespace InfinityMesh.Controllers
{
    [Authorize]
    public class UserController : Controller
    {

        private readonly IUser _userService;
        private readonly IMapper _mapper;

        public UserController(IUser userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Show(string keyword, string pageIndex)
        {

            var listOfUsers = _userService.GetAll(keyword);

            var list = _mapper.Map<List<UserIndexVM>>(listOfUsers);

            foreach (var item in list)
            {
                item.NumberOfBlogs = _userService.GetNumberOfBlogs(item.Id);
            }

            int? page = 1;
            if (pageIndex != null)
                page = Int32.Parse(pageIndex);

            var model = PagingList.Create(list, 5, page ?? 1);


            return PartialView(model);
        }

        public IActionResult Details(string id)
        {
            var user = _userService.GetById(id).Result;

            var model = _mapper.Map<UserDetailsVM>(user);

            return View(model);
        }

    }
}