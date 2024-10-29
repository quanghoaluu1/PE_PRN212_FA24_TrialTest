using GermanyEuro2024_BusinessObject;
using GermanyEuro2024_Repository;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        }
        private void NavigateToPage1(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PlayerInformation());
        }

    }
}