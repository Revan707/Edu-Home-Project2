using EduHome2.UI.Areas.EduHome2Admin.ViewModels.CourseViewModels;

namespace EduHome2.UI.Services.Interfaces;

public interface ICourseService
{
    Task<bool> CreateCourseAsync(CoursePostVM coursePostVM);
    Task<CourseDetailVM> GetCourseDetailByIdAsync(int id);
    Task<List<CourseVM>> GetAllCourseAsync();
}
