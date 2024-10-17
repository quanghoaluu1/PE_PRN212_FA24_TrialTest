using GermanyEuro2024_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GermanyEuro2024_DAO
{
    public class FootballPlayerDAO
    {
        private GermanyEuro2024DbContext _context;
        private static FootballPlayerDAO _instance;

        public FootballPlayerDAO()
        {
            _context = new GermanyEuro2024DbContext();
        }

        public static FootballPlayerDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FootballPlayerDAO();
                }
                return _instance;
            }
        }

        public List<FootballPlayer> GetFootballPlayerList()
        {
            return _context.FootballPlayers.ToList();
        }

        public FootballPlayer GetFootballPlayerById(string id)
        {
            return _context.FootballPlayers.SingleOrDefault(m => m.PlayerId.Equals(id));
        }
    }
}
