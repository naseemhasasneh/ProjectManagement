using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.validtionDtos
{
    public class ProjectPhaseDto
    {
        public List<Phase> Phases { get; set; }
        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectEndDate { get; set; }

    }
}
