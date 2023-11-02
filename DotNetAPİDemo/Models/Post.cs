using System.ComponentModel.DataAnnotations;

namespace DotNetAPİDemo.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter Title  ")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please Enter Description  ")]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
