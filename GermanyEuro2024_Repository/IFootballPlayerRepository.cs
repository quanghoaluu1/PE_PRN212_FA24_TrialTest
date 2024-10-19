using GermanyEuro2024_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GermanyEuro2024_Repository
{
    public interface IFootballPlayerRepository
    {
        public List<FootballPlayer> GetFootballPlayerList();
        public FootballPlayer GetFootballPlayerById(string id);

        public void AddFootballPlayer(FootballPlayer footballPlayer);
        public void RemoveFootballPlayer(string id);
        public void UpdateFootballPlayer(FootballPlayer updateFootballPlayer);
        public List<FootballPlayer> FindFootballPlayersByName(string name);
        public List<FootballPlayer> FindFootballPlayersByAchievements(string achievements);
    }
}
