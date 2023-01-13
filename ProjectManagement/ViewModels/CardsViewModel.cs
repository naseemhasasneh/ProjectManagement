﻿using System;
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
        public int ProjectsTotalNumber { get; set; }
        public int ClientsNumber { get; set; }
        public int TotalInvoices { get; set; }
        public double TotalProjectsAmount { get; set; }
    }
}
