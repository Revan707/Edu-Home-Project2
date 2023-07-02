﻿using EduHome2.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace HomeEdu.Core.Entities;

public class testimonial:IEntity
{
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string Name { get; set; } = null!;
    [Required, MaxLength(50)]
    public string Surname { get; set; } = null!;
    [Required, MaxLength(200)]
    public string Description { get; set; } = null!;
    [Required, MaxLength(50)]
    public string Position { get; set; } = null!;
    [Required, MaxLength(255)]
    public string ImagePath { get; set; } = null!;
}
