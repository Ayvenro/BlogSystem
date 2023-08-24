using AutoMapper;
using BlogSystem.Application.Features.Blogs;
using BlogSystem.Application.Features.Blogs.Queries.GetBlogDetail;
using BlogSystem.Application.Features.Categories.Queries.GetCategoriesList;
using BlogSystem.Application.Features.Categories.Queries.GetCategoriesListWithBlogs;
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
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryBlogListVm>();
        }
    }
}
