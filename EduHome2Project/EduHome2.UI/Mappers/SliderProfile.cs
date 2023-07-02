using AutoMapper;
using EduHome2.Core.Entities;
using EduHome2.UI.Areas.EduHome2Admin.ViewModels.SliderViewModels;

namespace EduHome2.UI.Mappers;

public class SliderProfile:Profile
{
    public SliderProfile()
    {
        CreateMap<SliderPostVM,Slider>().ReverseMap();
    }
}
