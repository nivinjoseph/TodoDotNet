using System.ComponentModel.DataAnnotations;


namespace TodoApi.Models
{
    public class CreateTodoModel
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}