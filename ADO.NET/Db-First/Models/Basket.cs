using System;
using System.Collections.Generic;

namespace Db_First.Models;

public partial class Basket
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<BasketProduct> BasketProducts { get; } = new List<BasketProduct>();

    public virtual User User { get; set; } = null!;
}
