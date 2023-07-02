using EduHome2.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EduHome2.Core.Entities;

public class Notice : IEntity
{
    public int Id { get ; set ; }
    public DateTime Date { get; set; }
    [Required, MaxLength(170)]
    public string Description { get; set; } = null!;

}
