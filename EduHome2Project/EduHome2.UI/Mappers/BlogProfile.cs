using AutoMapper;
using EduHome2.Core.Entities;
using EduHome2.UI.Areas.EduHome2Admin.ViewModels.BlogViewModels;
using EduHome2.UI.Areas.EduHome2Admin.ViewModels.SliderViewModels;

namespace EduHome2.UI.Mappers;

public class BlogProfile:Profile
{
    public BlogProfile()
    {
        CreateMap<BlogPostVM, Blog>().ReverseMap();
    }
}
