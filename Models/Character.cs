using System;
using System.Collections.Generic;

namespace EFcore.Models;

public partial class Character
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Role { get; set; }

    public int GameId { get; set; }

    public virtual Game Game { get; set; } = null!;
}
