using GermanyEuro2024_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            return _context.FootballPlayers.Include(p => p.FootballTeam).ToList();
        }

        public FootballPlayer GetFootballPlayerById(string id)
        {
            return _context.FootballPlayers.Include(p => p.FootballTeam).SingleOrDefault(m => m.PlayerId.Equals(id));
        }

        public void AddFootballPlayer(FootballPlayer footballPlayer)
        {
            _context.FootballPlayers.Add(footballPlayer);
            _context.SaveChanges();
        }

        public void RemoveFootballPlayer(string id)
        {
            _context.FootballPlayers.Remove(GetFootballPlayerById(id));
            _context.SaveChanges();
        }

        public void UpdateFootballPlayer(FootballPlayer updateFootballPlayer)
        {
            FootballPlayer footballPlayer = GetFootballPlayerById(updateFootballPlayer.PlayerId);
            footballPlayer.PlayerName = updateFootballPlayer.PlayerName;
            footballPlayer.Achievements = updateFootballPlayer.Achievements;
            footballPlayer.Award = updateFootballPlayer.Award;
            footballPlayer.Birthday = updateFootballPlayer.Birthday;
            footballPlayer.OriginCountry = updateFootballPlayer.OriginCountry;
            footballPlayer.FootballTeamId = updateFootballPlayer.FootballTeamId;
            _context.FootballPlayers.Update(updateFootballPlayer);
            _context.SaveChanges();
        }

        public List<FootballPlayer> FindFootballPlayersByName(string name)
        {
            List<FootballPlayer> footballPlayers = _context.FootballPlayers.Where(m => m.PlayerName.Contains(name)).ToList();
            return footballPlayers;
        }
        public List<FootballPlayer> FindFootballPlayersByAchievements(string achievements)
        {
            List<FootballPlayer> footballPlayers = _context.FootballPlayers.Where(m => m.Achievements.Contains(achievements)).ToList();
            return footballPlayers;
        }
    }
}
