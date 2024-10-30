using System.Windows;

namespace GermanyEuro2024_LuuQuangHoa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new PlayerInformation());
            TBlock1.Foreground = System.Windows.Media.Brushes.Red;
        }

        private void NavigateToPage1(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PlayerInformation());
            TBlock1.Foreground = System.Windows.Media.Brushes.Red;
            TBlock2.Foreground = System.Windows.Media.Brushes.Black;
        }

        private void NavigateToPage2(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new TeamInfomation());
            TBlock2.Foreground = System.Windows.Media.Brushes.Red;
            TBlock1.Foreground = System.Windows.Media.Brushes.Black;
        }
    }
}