using System.Windows;
using System.Windows.Controls;
using GermanyEuro2024_BusinessObject;
using GermanyEuro2024_Repository;

namespace GermanyEuro2024_LuuQuangHoa
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private UEFAAccountRepository _uefaAccountRepository;

        public LoginPage()
        {
            InitializeComponent();
            _uefaAccountRepository = new UEFAAccountRepository();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            Uefaaccount uefaaccount = _uefaAccountRepository.GetUEFAAccountByEmail(tbox_email.Text);
            if (uefaaccount != null && uefaaccount.AccountPassword.Equals(tbox_password.Password))
            {
                int? role = uefaaccount.Role;
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

            }
            else
            {
                MessageBox.Show("You have no permission to access this function!");
            }

        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }


    }
}
