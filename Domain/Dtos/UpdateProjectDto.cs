using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Dtos
{
    public class UpdateProjectDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Project Name is Required")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Contract Amount is Required")]
        public double ContractAmount { get; set; }
        [Required]
        public IFormFile ContractFile { get; set; }
        [Required(ErrorMessage = "Project Status is Required")]
        public int ProjectStatusId { get; set; }
        [Required(ErrorMessage = "Project Type is Required")]
        public int ProjectTypeId { get; set; }
    }
}
