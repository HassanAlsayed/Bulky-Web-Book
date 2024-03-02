using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Domain.Model
{
    public class ContactUs
    {
        [Required]
        public string From { get; set; } 

        public string To { get; set; } 
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
    }
}
