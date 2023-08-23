using AutoMapper;
using BlogSystem.Application.Features.Blogs;
using BlogSystem.Domain.Entities;

namespace BlogSystem.Application.Profiles
{
	public class MappingProfile : Profile
	{
        public MappingProfile()
        {
            CreateMap<Blog, BlogListVm>().ReverseMap();
            CreateMap<Blog, BlogDetailVm>().ReverseMap();
            CreateMap<Category, CategoryDto>();
        }
    }
}
