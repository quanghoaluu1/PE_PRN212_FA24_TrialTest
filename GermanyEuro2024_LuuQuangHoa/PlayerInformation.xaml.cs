using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GermanyEuro2024_BusinessObject;
using GermanyEuro2024_DAO.DTOs;
using GermanyEuro2024_Repository;

namespace GermanyEuro2024_LuuQuangHoa
{
    /// <summary>
    /// Interaction logic for PlayerInformation.xaml
    /// </summary>
    public partial class PlayerInformation : Page
    {
        private FootballPlayerRepository _footballPlayerRepository;
        private FootballTeamRepository _footballTeamRepository;
        private string _teamId = null;
        public PlayerInformation()
        {
            InitializeComponent();
            _footballPlayerRepository = new FootballPlayerRepository();
            _footballTeamRepository = new FootballTeamRepository();
            
        }

        public PlayerInformation(string teamId)
        {
            InitializeComponent();
            _footballPlayerRepository = new FootballPlayerRepository();
            _footballTeamRepository = new FootballTeamRepository();
            _teamId = teamId;
            

        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_teamId))
            {
              loadDataInit();
            }
            else
            {
                List<FootballTeam> footballTeams = _footballTeamRepository.GetAllTeams();
                List<FootballPlayer> footballPlayers = _footballPlayerRepository.FindFootballPlayersByTeam(_teamId);
                List<FootballPlayerDTO> footballPlayerDTOs = _footballPlayerRepository.ConvertToDTOList(footballPlayers);
                dtg_footballPlayerInformation.ItemsSource = footballPlayerDTOs;
            }
            
        }
        public void loadDataInit()
        {
            List<FootballTeam> footballTeams = _footballTeamRepository.GetAllTeams();
            List<FootballPlayer> footballPlayers = _footballPlayerRepository.GetFootballPlayerList();
            List<FootballPlayerDTO> footballPlayerDTOs = _footballPlayerRepository.ConvertToDTOList(footballPlayers);
            dtg_footballPlayerInformation.ItemsSource = footballPlayerDTOs;

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void dtg_footballPlayerInformation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           var image = sender as Image;
            if(image != null)
            {
                string playerId = image.Tag as string;
                PlayerDetail playerDetail = new PlayerDetail(playerId);
                bool? result = playerDetail.ShowDialog();
                if (result == true)
                {
                    loadDataInit();
                }
            }
        }

        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            PlayerDetail playerDetail = new PlayerDetail();
            bool? result = playerDetail.ShowDialog();
            if (result == true)
            {
                loadDataInit();
            }
        }

        private void BtnSearch_OnClick(object sender, RoutedEventArgs e)
        {
            string searchValue = TbSearch.Text;
            if (string.IsNullOrEmpty(searchValue))
            {
                dtg_footballPlayerInformation.ItemsSource = _footballPlayerRepository.ConvertToDTOList(_footballPlayerRepository.GetFootballPlayerList());
            }
            else if (CboxItemName.IsSelected)
            {
                dtg_footballPlayerInformation.ItemsSource = _footballPlayerRepository.ConvertToDTOList(_footballPlayerRepository.FindFootballPlayersByName(searchValue));
            }
            else if (CboxItemAchievement.IsSelected)
            {
                dtg_footballPlayerInformation.ItemsSource = _footballPlayerRepository.ConvertToDTOList(_footballPlayerRepository.FindFootballPlayersByAchievements(searchValue));
            }
        }
    }
}
