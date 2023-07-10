using EduHome2.Core.Interfaces;

namespace EduHome2.Core.Entities;

public class Assesment : IEntity
{
    public int Id { get ; set ; }
    public string? AssesmentType { get; set; }
    CourseDetail? CourseDetail { get; set; }
}
