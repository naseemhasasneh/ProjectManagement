using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMISBLayer.Entities
{
    public class Phase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProjectPhase> ProjectPhase { get; set; }
    }
}
