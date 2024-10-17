using GermanyEuro2024_BusinessObject;
using GermanyEuro2024_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GermanyEuro2024_Repository
{
    public class UEFAAccountRepository : IUEFAAccountRepository
    {
        public Uefaaccount GetUEFAAccountByEmail(string email)
        {
            return UEFAAccountDAO.Instance.GetUEFAAccountByEmail(email);
        }
    }
}
