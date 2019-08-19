using AutoMapper;
using InfinityMesh.Data.Data.Model;
using InfinityMesh.ViewModels;
using InfinityMesh.ViewModels.Blog;
using Microsoft.AspNetCore.Identity;

namespace InfinityMesh.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<AppUser, UserIndexVM>().ReverseMap();
            CreateMap<AppUser, UserDetailsVM>().ReverseMap();
            CreateMap<Blog, BlogAddVM>().ReverseMap();
            CreateMap<Blog, BlogShowVM>().ReverseMap();
        }
    }
}
