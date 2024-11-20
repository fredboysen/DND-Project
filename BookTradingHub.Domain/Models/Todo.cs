namespace DNDProject.Domain.Models;

public record Todo
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }

}