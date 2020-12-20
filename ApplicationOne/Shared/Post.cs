using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationOne.Shared
{
   public class Post
    {
        public int id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "This field cannot be more then 50 character")]
        public string URL { get; set; }
        public string Image { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "This field cannot be more then 50 character")]
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "this field is required")]
        public bool isPublished { get; set; } = true;
        public bool isDeleted { get; set; } = false;

    }
}
