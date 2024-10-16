using System;
using System.Collections.Generic;

namespace GermanyEuro2024_LuuQuangHoa;

public partial class FootballPlayer
{
    public string PlayerId { get; set; } = null!;

    public string PlayerName { get; set; } = null!;

    public string Achievements { get; set; } = null!;

    public DateTime? Birthday { get; set; }

    public string OriginCountry { get; set; } = null!;

    public string Award { get; set; } = null!;

    public string? FootballTeamId { get; set; }

    public virtual FootballTeam? FootballTeam { get; set; }
}
