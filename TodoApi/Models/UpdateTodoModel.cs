using System.ComponentModel.DataAnnotations;


namespace TodoApi.Models
{
    public class UpdateTodoModel : CreateTodoModel
    {
        [Required]
        public string Id { get; set; }
    }
}