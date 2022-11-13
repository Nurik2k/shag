using System;
using System.Collections.Generic;

namespace Finaldb.Models;

public partial class Group
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int OwnerId { get; set; }

    public virtual ICollection<GroupMessage> GroupMessages { get; } = new List<GroupMessage>();

    public virtual User Owner { get; set; } = null!;

    public virtual ICollection<UserGroup> UserGroups { get; } = new List<UserGroup>();
}
