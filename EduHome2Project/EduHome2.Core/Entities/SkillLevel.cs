using EduHome2.Core.Interfaces;

namespace EduHome2.Core.Entities;

public class SkillLevel : IEntity
{
    public int Id { get ; set ; }
    public string? Skill { get; set; }
    CourseDetail? CourseDetail { get; set; }
}
