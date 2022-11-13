using System;
using System.Collections.Generic;

namespace Finaldb.Models;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string? Password { get; set; }

    public virtual ICollection<GroupMessage> GroupMessages { get; } = new List<GroupMessage>();

    public virtual ICollection<Group> Groups { get; } = new List<Group>();

    public virtual ICollection<PrivateMessage> PrivateMessageFromUsers { get; } = new List<PrivateMessage>();

    public virtual ICollection<PrivateMessage> PrivateMessageToUsers { get; } = new List<PrivateMessage>();

    public virtual ICollection<UserGroup> UserGroups { get; } = new List<UserGroup>();
}
