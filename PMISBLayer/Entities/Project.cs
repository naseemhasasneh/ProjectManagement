using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PMISBLayer.Entities
{
    public class Project
    {
        public int Id { get; set; }
        [Required]
        public string Name  { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public double ContractAmount { get; set; }
        [Required]
        public string ContractFileName { get; set; }
        [Required]
        public string ContractFileType { get; set; }
        [Required]
        public Byte[] ContractFile{ get; set; }
        [Required]
        public int ProjectStatusId { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        [Required]
        public int ProjectTypeId { get; set; }
        public ProjectType ProjectType { get; set; }
        public List<ProjectPhase> ProjectPhase { get; set; }
        public string ProjectManagerId { get; set; }
        public ProjectManager ProjectManager { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
