using System;
using System.Collections.Generic;
using Models;
namespace Visitor_Placement_Tool.ViewModels
{
    public class BezoekerViewModel
    {
        public List<Bezoeker> Bezoekers { get; set; }
        public int EvenementId { get; set; }
        public int MaxBezoekers { get; set; }
    }
}
