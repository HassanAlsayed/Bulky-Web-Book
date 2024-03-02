using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Domain.Model
{
    public class Category
    {
        [Key]
        [Display(Name = "Category Id")]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [Range(0, 100)]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
