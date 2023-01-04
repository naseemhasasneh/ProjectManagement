using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Dtos
{
    public class CreateClientDto
    {
        [Required(ErrorMessage = "Client Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Client Email is Required")]
        public string Email { get; set; }
    }
}
