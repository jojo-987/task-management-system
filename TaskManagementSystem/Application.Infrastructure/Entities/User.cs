using System;
using System.Collections.Generic;

namespace Application.Infrastructure.Entities;

public partial class User
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
