using GermanyEuro2024_BusinessObject;

namespace GermanyEuro2024_Repository
{
    public interface IUefaAccountRepository
    {
        public Uefaaccount GetUEFAAccountByEmail(string email);
    }
}
