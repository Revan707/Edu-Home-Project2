using EduHome2.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome2.Core.Entities;

public class Event : IEntity
{
    public int Id { get ; set ; }
    public DateTime Start { get ; set ; }
    public DateTime End { get ; set ; }
    public string? Location { get ; set ; }
}
