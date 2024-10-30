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
        private string _teamId = "";
        private int? _role = 0;
        public PlayerInformation()
        {
            InitializeComponent();
            _footballPlayerRepository = new FootballPlayerRepository();
            _footballTeamRepository = new FootballTeamRepository();
            
        }

        public PlayerInformation(string teamId, int? role)
        {
            InitializeComponent();
            _footballPlayerRepository = new FootballPlayerRepository();
            _footballTeamRepository = new FootballTeamRepository();
            _teamId = teamId;
            _role = role;
            switch (role)
            {
                case 2:
                    ImageAdd.Visibility= Visibility.Hidden;
                    TextBlockAdd.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    break;
            }
        }

        public PlayerInformation(int? role)
        {
            InitializeComponent();
            _footballPlayerRepository = new FootballPlayerRepository();
            _footballTeamRepository = new FootballTeamRepository();
            _role = role;
            switch (role)
            {
                case 2:
                    ImageAdd.Visibility= Visibility.Hidden;
                    TextBlockAdd.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    break;
            }
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
                DtgFootballPlayerInformation.ItemsSource = footballPlayerDTOs;
            }
            
        }
        public void loadDataInit()
        {
            List<FootballTeam> footballTeams = _footballTeamRepository.GetAllTeams();
            List<FootballPlayer> footballPlayers = _footballPlayerRepository.GetFootballPlayerList();
            List<FootballPlayerDTO> footballPlayerDTOs = _footballPlayerRepository.ConvertToDTOList(footballPlayers);
            DtgFootballPlayerInformation.ItemsSource = footballPlayerDTOs;

        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           var image = sender as Image;
            if(image != null)
            {
                string playerId = image.Tag as string;
                PlayerDetail playerDetail = new PlayerDetail(playerId, _role);
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
                DtgFootballPlayerInformation.ItemsSource = _footballPlayerRepository.ConvertToDTOList(_footballPlayerRepository.GetFootballPlayerList());
            }
            else if (CboxItemName.IsSelected)
            {
                DtgFootballPlayerInformation.ItemsSource = _footballPlayerRepository.ConvertToDTOList(_footballPlayerRepository.FindFootballPlayersByName(searchValue));
            }
            else if (CboxItemAchievement.IsSelected)
            {
                DtgFootballPlayerInformation.ItemsSource = _footballPlayerRepository.ConvertToDTOList(_footballPlayerRepository.FindFootballPlayersByAchievements(searchValue));
            }
        }
    }
}
