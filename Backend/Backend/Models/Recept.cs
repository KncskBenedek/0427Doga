using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Recept
{
    public int Id { get; set; }

    public string Nev { get; set; } = null!;

    public int KatId { get; set; }

    public string KepEleresiUt { get; set; } = null!;

    public string Leiras { get; set; } = null!;

    public virtual Kategorium Kat { get; set; } = null!;
}
