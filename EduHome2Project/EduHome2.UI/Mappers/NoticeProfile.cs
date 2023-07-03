using AutoMapper;
using EduHome2.Core.Entities;
using EduHome2.UI.Areas.EduHome2Admin.ViewModels.NoticeViewModels;

namespace EduHome2.UI.Mappers;

public class NoticeProfile:Profile
{
    public NoticeProfile()
    {
        CreateMap<NoticePostVM, Notice>().ReverseMap();
    }
}
