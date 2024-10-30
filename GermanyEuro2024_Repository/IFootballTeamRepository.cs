using GermanyEuro2024_BusinessObject;

namespace GermanyEuro2024_Repository
{
    public interface IFootballTeamRepository
    {
        List<FootballTeam> GetAllTeams();
        FootballTeam GetFootballTeamByID(string id);
    }
}
