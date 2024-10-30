using GermanyEuro2024_BusinessObject;
using GermanyEuro2024_DAO;

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
            return FootballTeamDAO.Instance.GetFootballTeamById(id);
        }
    }
}
