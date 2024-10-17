﻿using GermanyEuro2024_BusinessObject;
using GermanyEuro2024_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GermanyEuro2024_Repository
{
    public class FootballPlayerRepository : IFootballPlayerRepository
    {
        public List<FootballPlayer> GetFootballPlayerList()
        {
           return FootballPlayerDAO.Instance.GetFootballPlayerList();
        }

        public FootballPlayer GetFootballPlayerById(string id)
        {
            return FootballPlayerDAO.Instance.GetFootballPlayerById(id);
        }
    }
}