using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EFcore.Models;

public partial class Game
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ReleaseYear { get; set; }
    
    public string Developer { get; set; } = String.Empty;
        
    [JsonIgnore]
    public virtual ICollection<Character> Characters { get; set; } = new List<Character>();
}
