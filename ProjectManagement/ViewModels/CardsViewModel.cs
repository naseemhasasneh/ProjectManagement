using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.ViewModels
{
    public class CardsViewModel
    {
        public int ProgressProjectsNumber { get; set; }
        public int NotStartedProjectsNumber { get; set; }
        public int CompletedProjectsNumber { get; set; }
        public double TotalProjectsAmount { get; set; }
    }
}
