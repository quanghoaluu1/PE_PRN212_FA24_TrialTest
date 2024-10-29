using GermanyEuro2024_BusinessObject;
using GermanyEuro2024_LuuQuangHoa;
using GermanyEuro2024_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GermanyEuro2024_WPF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private UEFAAccountRepository _uefaAccountRepository;

        public LoginWindow()
        {
            InitializeComponent();
            _uefaAccountRepository = new UEFAAccountRepository();
        }

  
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Uefaaccount uefaaccount = _uefaAccountRepository.GetUEFAAccountByEmail(tboxEmail.Text);
            if (uefaaccount != null && uefaaccount.AccountPassword.Equals(tboxPassword.Password))
            {
                int? role = uefaaccount.Role;
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("You have no permission to access this function!");
            }

        }

    }
}
