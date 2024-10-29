using GermanyEuro2024_BusinessObject;
using GermanyEuro2024_DAO.DTOs;
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
    /// Interaction logic for PlayerInformation.xaml
    /// </summary>
    public partial class PlayerInformation : Page
    {
        private FootballPlayerRepository _footballPlayerRepository;
        private FootballTeamRepository _footballTeamRepository;
        public PlayerInformation()
        {
            InitializeComponent();
            _footballPlayerRepository = new FootballPlayerRepository();
            _footballTeamRepository = new FootballTeamRepository();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            loadDataInit();
        }
        private void loadDataInit()
        {
            List<FootballTeam> footballTeams = _footballTeamRepository.GetAllTeams();
            List<FootballPlayer> footballPlayers = _footballPlayerRepository.GetFootballPlayerList();
            List<FootballPlayerDTO> footballPlayerDTOs = _footballPlayerRepository.ConvertToDTOList(footballPlayers);
            this.dtg_footballPlayerInformation.ItemsSource = footballPlayerDTOs;

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void dtg_footballPlayerInformation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           var image = sender as Image;
            if(image != null)
            {
                string playerId = image.Tag as string;
                MessageBox.Show(playerId);
                PlayerDetail playerDetail = new PlayerDetail(playerId);
                playerDetail.ShowDialog();
            }
        }
    }
}
