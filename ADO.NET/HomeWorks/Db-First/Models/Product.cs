using System;
using System.Collections.Generic;

namespace Db_First.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public int Count { get; set; }

    public virtual ICollection<BasketProduct> BasketProducts { get; } = new List<BasketProduct>();
}
