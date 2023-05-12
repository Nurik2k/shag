using System;
using System.Collections.Generic;

namespace Db_First.Models;

public partial class BasketProduct
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int BasketId { get; set; }

    public virtual Basket Basket { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
