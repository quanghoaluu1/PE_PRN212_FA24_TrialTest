using GermanyEuro2024_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GermanyEuro2024_Repository
{
    public interface IFootballTeamRepository
    {
        List<FootballTeam> GetAllTeams();
        FootballTeam GetFootballTeamByID(string id);
    }
}
