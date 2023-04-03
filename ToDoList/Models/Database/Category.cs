using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Models.Database;

[Table("Category")]
public partial class Category
{
    [Key]
    public Guid? ID { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreatedOn { get; set; }

    public List<TodoItem>? TodoItems { get; set; }
}
