using System;
using System.Collections.Generic;

namespace Finaldb.Models;

public partial class PrivateMessage
{
    public int Id { get; set; }

    public int FromUserId { get; set; }

    public int ToUserId { get; set; }

    public string Message { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public bool IsUserInBlackList { get; set; }

    public string? AdditionalInfo { get; set; }

    public bool IsDeleted { get; set; }

    public virtual User FromUser { get; set; } = null!;

    public virtual User ToUser { get; set; } = null!;
}
