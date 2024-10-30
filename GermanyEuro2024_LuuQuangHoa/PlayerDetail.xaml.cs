using System.Text.RegularExpressions;
using System.Windows;
using GermanyEuro2024_BusinessObject;
using GermanyEuro2024_Repository;
using MessageBox = System.Windows.MessageBox;

namespace GermanyEuro2024_LuuQuangHoa
{
    /// <summary>
    /// Interaction logic for PlayerDetail.xaml
    /// </summary>
    public partial class PlayerDetail : Window
    {
        private FootballPlayerRepository _footballPlayerRepository;
        private FootballTeamRepository _footballTeamRepository;
        private string _playerId = "" ;
        public PlayerDetail()
        {
            _footballPlayerRepository = new FootballPlayerRepository();
            _footballTeamRepository = new FootballTeamRepository();
            InitializeComponent();
        }
        public PlayerDetail(string playerId, int? role)
        {
            InitializeComponent();
            _playerId = playerId;
            _footballPlayerRepository = new FootballPlayerRepository();
            _footballTeamRepository = new FootballTeamRepository();
            switch (role)
            {
                case 3 :
                    BtnDelete.Visibility = Visibility.Visible;
                    BtnUpdate.Visibility = Visibility.Visible;
                    break;
                case 2:
                    Disable();
                    break;
                
            }
        }

        private void Disable()
        {
            TboxPlayerId.IsEnabled = false;
            TboxPlayerName.IsEnabled = false;
            TboxAchievement.IsEnabled = false;
            DateBirthday.IsEnabled = false;
            TbAward.IsEnabled = false;
            TboxOriginCountry.IsEnabled = false;
            CboxTeamTitle.IsEnabled = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            List<FootballTeam> footballTeams = _footballTeamRepository.GetAllTeams();
            
            CboxTeamTitle.ItemsSource = footballTeams;
            CboxTeamTitle.DisplayMemberPath = "TeamTitle";
            CboxTeamTitle.SelectedValuePath = "FootballTeamId";
            if(_playerId != "")
            {
                LoadDataInit();
            }
            else
            {
                LoadBlankData();
            }
            
        }

        private void LoadDataInit()
        {
            FootballPlayer footballPlayer = _footballPlayerRepository.GetFootballPlayerById(_playerId);
            TboxPlayerId.Text = footballPlayer.PlayerId;
            TboxPlayerName.Text = footballPlayer.PlayerName;
            TboxAchievement.Text = footballPlayer.Achievements;
            DateBirthday.Text = footballPlayer.Birthday.ToString();
            TbAward.Text = footballPlayer.Award;
            TboxOriginCountry.Text = footballPlayer.OriginCountry;
            CboxTeamTitle.SelectedValue = footballPlayer.FootballTeamId;
            TboxPlayerId.IsEnabled = false;
        }
        
        private void LoadBlankData()
        {
            TboxPlayerId.Text = GetNewId();
            TboxPlayerId.IsEnabled = false;
            TboxPlayerName.Text = "";
            TboxAchievement.Text = "";
            DateBirthday.Text = "";
            TbAward.Text = "";
            TboxOriginCountry.Text = "";
            CboxTeamTitle.SelectedIndex = 0;
            BtnAdd.Visibility = Visibility.Visible;
        }

        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            FootballPlayer footballPlayer = new FootballPlayer();
            footballPlayer.PlayerId = GetNewId();
            if (ExistedPlayerId(footballPlayer.PlayerId))
            {
                MessageBox.Show("Player Id existed");
                return;
            }
            footballPlayer.PlayerName = TboxPlayerName.Text;
            if (!IsValidName(footballPlayer.PlayerName))
            {
                MessageBox.Show("Invalid name");
                return;
            }
            footballPlayer.Achievements = TboxAchievement.Text;
            footballPlayer.Birthday = DateTime.Parse(DateBirthday.Text);
            if (footballPlayer.Birthday > new DateTime(2004, 1, 1))
            {
                MessageBox.Show("We only accept players born before 2004");
                return;
            }
            footballPlayer.Award = TbAward.Text;
            footballPlayer.OriginCountry = TboxOriginCountry.Text;
            footballPlayer.FootballTeamId = CboxTeamTitle.SelectedValue.ToString();
            
            
            _footballPlayerRepository.AddFootballPlayer(footballPlayer);
            
            
            if (_footballPlayerRepository.GetFootballPlayerList().Contains(footballPlayer))
            {
                MessageBox.Show("Add successfully");
                DialogResult = true;
                
            }
        }

        private string GetNewId()
        {
            List<FootballPlayer> footballPlayers = _footballPlayerRepository.GetFootballPlayerList();
            FootballPlayer lastFootballPlayer = footballPlayers.OrderBy(p => p.PlayerId).LastOrDefault();
            int number =  int.Parse(lastFootballPlayer.PlayerId.Substring(2)) + 1;
            return $"PL{number:D5}";
        }
        private bool ExistedPlayerId(string playerId)
        {
            return _footballPlayerRepository.GetFootballPlayerList().Exists(player => player.PlayerId == playerId);
        }
        
        private bool IsValidName(string name)
        {
            bool result = name.Length is >= 3 and <= 100;
            if (!Regex.IsMatch(name, @"^[A-Za-z0-9 ]+$"))
            {
                result = false;
            }
            string[] words = name.Split(' ');
            foreach (string word in words)
            {
                if (!Regex.IsMatch(word, @"^[A-Z0-9]"))
                {
                    result = false;
                }
            }
            return result;
        }

        private void BtnUpdate_OnClick(object sender, RoutedEventArgs e)
        {
            FootballPlayer updatePlayer = _footballPlayerRepository.GetFootballPlayerById(_playerId);

            updatePlayer.PlayerName = TboxPlayerName.Text;
            if (!IsValidName(updatePlayer.PlayerName))
            {
                MessageBox.Show("Invalid name");
                return;
            }
            updatePlayer.Achievements = TboxAchievement.Text;
            updatePlayer.Birthday = DateTime.Parse(DateBirthday.Text);
            if (updatePlayer.Birthday > new DateTime(2004, 1, 1))
            {
                MessageBox.Show("We only accept players born before 2004");
                return;
            }
            updatePlayer.Award = TbAward.Text;
            updatePlayer.OriginCountry = TboxOriginCountry.Text;
            updatePlayer.FootballTeamId = CboxTeamTitle.SelectedValue.ToString();
            _footballPlayerRepository.UpdateFootballPlayer(updatePlayer);
            if (_footballPlayerRepository.GetFootballPlayerList().Contains(updatePlayer))
            {
                MessageBox.Show("Update successfully");
                DialogResult = true;
            }
            
        }

        private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
        {
            string id = _playerId;
            _footballPlayerRepository.RemoveFootballPlayer(_playerId);
            if (!_footballPlayerRepository.GetFootballPlayerList()
                .Contains(_footballPlayerRepository.GetFootballPlayerById(id)))
            {
              MessageBox.Show("Delete successfully");
                DialogResult = true;
            }
        }
    }
}
