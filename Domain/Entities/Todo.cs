namespace Domain.Entities;

public class Todo
{
    public Todo(string owner, string title)
    {
        Id = Guid.NewGuid().ToString();
        Owner = owner;
        Title = title;
        Completed = false;
        CreatedAt = DateTime.UtcNow;
    }

    private Todo(string id, string owner, string title, bool completed, DateTime createdAt, DateTime? completedAt)
    {
        Id = id;
        Owner = owner;
        Title = title;
        Completed = completed;
        CreatedAt = createdAt;
        CompletedAt = completedAt;
    }

    public string Id { get; }
    public string Owner { get; }
    public string Title { get; }
    public bool Completed { get; private set; }
    public DateTime CreatedAt { get; }
    public DateTime? CompletedAt { get; private set; }

    public static Todo Load(string id, string owner, string title, bool completed, DateTime createdAt, DateTime? completedAt)
    {
        return new Todo(id, owner, title, completed, createdAt, completedAt);
    }

    public void Complete()
    {
        Completed = true;
        CompletedAt = DateTime.UtcNow;
    }
}