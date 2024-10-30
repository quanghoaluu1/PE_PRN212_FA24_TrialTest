using GermanyEuro2024_BusinessObject;
using GermanyEuro2024_DAO;

namespace GermanyEuro2024_Repository
{
    public class UefaAccountRepository : IUefaAccountRepository
    {
        public Uefaaccount GetUEFAAccountByEmail(string email)
        {
            return UEFAAccountDAO.Instance.GetUefaAccountByEmail(email);
        }
    }
}
