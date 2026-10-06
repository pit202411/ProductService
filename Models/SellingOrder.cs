using System;
using System.Collections.Generic;

namespace ProductsService.Models;

public partial class SellingOrder
{
    public int IdSellingOrder { get; set; }

    public int IdEmployee { get; set; }

    public int IdProduct { get; set; }

    public int Quantity { get; set; }

    public virtual Employee IdEmployeeNavigation { get; set; } = null!;

    public virtual Product IdProductsNavigation { get; set; } = null!;
}
