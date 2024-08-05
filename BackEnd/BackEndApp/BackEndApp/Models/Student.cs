using System;
using System.Collections.Generic;

namespace BackEndApp.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string StudentNumber { get; set; } = null!;
        public decimal? AverageMark { get; set; }

        public virtual Person StudentNavigation { get; set; } = null!;
    }
}
