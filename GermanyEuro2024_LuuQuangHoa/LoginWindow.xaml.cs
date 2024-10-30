using System.Windows;
using GermanyEuro2024_BusinessObject;
using GermanyEuro2024_LuuQuangHoa;
using GermanyEuro2024_Repository;

namespace GermanyEuro2024_WPF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private UefaAccountRepository _uefaAccountRepository;

        public LoginWindow()
        {
            InitializeComponent();
            _uefaAccountRepository = new UefaAccountRepository();
        }

  
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Uefaaccount uefaaccount = _uefaAccountRepository.GetUEFAAccountByEmail(TboxEmail.Text);
            if (uefaaccount.AccountPassword.Equals(TboxPassword.Password))
            {
                int? role = uefaaccount.Role;
                if (role == 1 || role == 4)
                {
                    MessageBox.Show("You have no permission to access this function!");
                }
                else
                {
                    MainWindow mainWindow = new MainWindow(role);
                    mainWindow.Show();
                    Close();  
                }
                
            }
            else
            {
                MessageBox.Show("You have no permission to access this function!");
            }

        }

    }
}
