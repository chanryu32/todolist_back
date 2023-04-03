using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models.Database;

public partial class TodoListDbContext : DbContext
{
    public TodoListDbContext()
    {
    }

    public TodoListDbContext(DbContextOptions<TodoListDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<TodoItem> TodoItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.ID).ValueGeneratedNever();
        });

        modelBuilder.Entity<TodoItem>(entity =>
        {
            entity.Property(e => e.ID).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
