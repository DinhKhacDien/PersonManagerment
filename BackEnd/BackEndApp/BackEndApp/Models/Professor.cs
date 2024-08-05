using System;
using System.Collections.Generic;

namespace BackEndApp.Models
{
    public partial class Professor
    {
        public int ProfessorId { get; set; }
        public decimal? Salary { get; set; }

        public virtual Person ProfessorNavigation { get; set; } = null!;
    }
}
