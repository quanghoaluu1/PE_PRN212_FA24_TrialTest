using GermanyEuro2024_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GermanyEuro2024_DAO
{
    public class UEFAAccountDAO
    {
        private GermanyEuro2024DbContext _context;
        private static UEFAAccountDAO _instance;

        public UEFAAccountDAO()
        {
            _context = new GermanyEuro2024DbContext();
        }

        public static UEFAAccountDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UEFAAccountDAO();
                }
                return _instance;
            }
        }

        public Uefaaccount GetUefaAccountByEmail(string email)
        {
            return _context.Uefaaccounts.SingleOrDefault(m => m.AccountEmail.Equals(email));
        }
    }
}
