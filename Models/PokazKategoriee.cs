using System;
using System.Collections.Generic;

namespace ProductsService.Models;

public partial class PokazKategoriee
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public byte[]? Picture { get; set; }
}
