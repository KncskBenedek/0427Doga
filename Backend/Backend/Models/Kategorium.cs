using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Backend.Models;

public partial class Kategorium
{
    public int Id { get; set; }

    public string Nev { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Recept> Recepts { get; set; } = new List<Recept>();
}
