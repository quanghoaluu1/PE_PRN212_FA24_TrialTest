using System.Windows;
using System.Windows.Input;
using GermanyEuro2024_WPF;

namespace GermanyEuro2024_LuuQuangHoa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int? _role;
        public MainWindow(int? role)
        {
            InitializeComponent();
                TBlock1.Foreground = System.Windows.Media.Brushes.Red;
                TBlock2.Foreground = System.Windows.Media.Brushes.Black;
                _role = role;
                MainFrame.Navigate(new PlayerInformation(_role));
        }
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new PlayerInformation());
            TBlock1.Foreground = System.Windows.Media.Brushes.Red;
        }

        private void NavigateToPage1(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PlayerInformation(_role));
            TBlock1.Foreground = System.Windows.Media.Brushes.Red;
            TBlock2.Foreground = System.Windows.Media.Brushes.Black;
        }

        private void NavigateToPage2(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new TeamInfomation(_role));
            TBlock2.Foreground = System.Windows.Media.Brushes.Red;
            TBlock1.Foreground = System.Windows.Media.Brushes.Black;
        }

        private void UIElement_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
            
        }
    }
}