using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Models.Database;

[Table("TodoItem")]
public partial class TodoItem
{
    [Key]
    public Guid? ID { get; set; }

    public string InputValue { get; set; } = null!;

    public bool IsCompleted { get; set; } = false;

    public DateTime? LastUpdatedOn { get; set; }

    public DateTime? CreatedOn { get; set; }

    public Guid CategoryId { get; set; }
}
