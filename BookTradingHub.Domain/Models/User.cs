namespace DNDProject.Domain.Models;

public record User
{
    public int Id { get; set; }
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    public string Email { get; set; } = "";
    public string FullName { get; set; } = "";
    public DateTime Birthday { get; set; }
    public string Domain { get; set; } = "";
    public string Role { get; set; } = "";
    public int SecurityLevel { get; set; }
}
