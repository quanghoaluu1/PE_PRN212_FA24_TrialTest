using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GermanyEuro2024_BusinessObject;

namespace GermanyEuro2024_DAO
{
    public class FootballTeamDAO
    {
        private GermanyEuro2024DbContext _context;
        private static FootballTeamDAO _instance;

        private FootballTeamDAO()
        {
            _context = new GermanyEuro2024DbContext();
        }

        public static FootballTeamDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FootballTeamDAO();
                }
                return _instance;
            }
        }

        public List<FootballTeam> GetAllTeams()
        {
            return _context.FootballTeams.ToList();
        }

        public FootballTeam GetFootballTeamByID(string id)
        {
            return _context.FootballTeams.SingleOrDefault(m => m.FootballTeamId.Equals(id));
        }
    }
}
