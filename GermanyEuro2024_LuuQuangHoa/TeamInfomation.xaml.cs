using GermanyEuro2024_BusinessObject;
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

namespace GermanyEuro2024_LuuQuangHoa
{
    /// <summary>
    /// Interaction logic for TeamInfomation.xaml
    /// </summary>
    public partial class TeamInfomation : Page
    {
        private FootballTeamRepository _footballTeamRepository;
        private int? _role = 0;
        public TeamInfomation(int? role)
        {
            InitializeComponent();
            _footballTeamRepository = new FootballTeamRepository();
            _role = role;
        }

        public void Page_Loaded(object sender, RoutedEventArgs e)
        {
            loadDataInit();
        }
        private void loadDataInit()
        {
            List<FootballTeam> footballTeams = _footballTeamRepository.GetAllTeams();
            
            DtgTeamInformation.ItemsSource = footballTeams;
        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var image = sender as Image;
            if (image != null)
            {
                string teamId = image.Tag as string;
                NavigationService.Navigate(new PlayerInformation(teamId, _role));

            }
        }
    }
}
