using EduHome2.Core.Interfaces;

namespace EduHome2.Core.Entities;

public class CourseDetail : IEntity
{
    public int Id { get ; set ; }
    public string? HowToApply { get; set; }
    public string? AboutCourse { get; set; }
    public string? Certification { get; set; }
    public DateTime Start { get; set; }
    public string? Duration { get; set; }
    public string? ClassDuration { get; set; }
    public decimal CourseFee { get; set; }
    public Course? Course { get; set; }
    public Language? LanguageOption { get; set; }
    public Assesment? Assesment { get; set; }
    public SkillLevel? Skill { get; set; }
    public int LanguageOptionId { get; set; }
    public int AssesmentId { get; set; }
    public int SkillId { get; set; }
    public int StudentCount { get; set; }
}
