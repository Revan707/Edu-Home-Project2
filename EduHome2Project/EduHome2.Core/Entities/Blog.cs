using EduHome2.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EduHome2.Core.Entities;

public class Blog : IEntity
{
    public int Id { get ; set ; }
    [Required, MaxLength(255)]
    public string ImagePath { get; set; } = null!;
    public string Name { get; set; } = null!;
    public DateTime Date { get ; set ; }
    public int MessageBox { get ; set ; }
    public string Description { get ; set ; }= null!;
}
