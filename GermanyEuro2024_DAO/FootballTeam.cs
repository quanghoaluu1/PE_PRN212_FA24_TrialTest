using System;
using System.Collections.Generic;

namespace GermanyEuro2024_LuuQuangHoa;

public partial class FootballTeam
{
    public string FootballTeamId { get; set; } = null!;

    public string TeamTitle { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string ManagerName { get; set; } = null!;

    public virtual ICollection<FootballPlayer> FootballPlayers { get; set; } = new List<FootballPlayer>();
}
