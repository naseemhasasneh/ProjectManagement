using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PMISBLayer.Entities
{
    public class Client
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Client Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Client Email is Required")]
        public string Email { get; set; }
    }
}
