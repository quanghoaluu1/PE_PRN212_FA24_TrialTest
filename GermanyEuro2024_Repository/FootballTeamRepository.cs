using GermanyEuro2024_BusinessObject;
using GermanyEuro2024_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GermanyEuro2024_Repository
{
    public class FootballTeamRepository : IFootballTeamRepository
    {
        public List<FootballTeam> GetAllTeams()
        {
            return FootballTeamDAO.Instance.GetAllTeams();
        }

        public FootballTeam GetFootballTeamByID(string id)
        {
            return FootballTeamDAO.Instance.GetFootballTeamByID(id);
        }
    }
}
