using System.Text.RegularExpressions;
using System.Windows;
using GermanyEuro2024_BusinessObject;
using GermanyEuro2024_Repository;

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
        public PlayerDetail(string playerId)
        {
            InitializeComponent();
            _playerId = playerId;
            _footballPlayerRepository = new FootballPlayerRepository();
            _footballTeamRepository = new FootballTeamRepository();
        }   

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            List<FootballTeam> footballTeams = _footballTeamRepository.GetAllTeams();
            
            cboxTeamTitle.ItemsSource = footballTeams;
            cboxTeamTitle.DisplayMemberPath = "TeamTitle";
            cboxTeamTitle.SelectedValuePath = "FootballTeamId";
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
            tboxPlayerId.Text = footballPlayer.PlayerId;
            tboxPlayerName.Text = footballPlayer.PlayerName;
            tboxAchievement.Text = footballPlayer.Achievements;
            dateBirthday.Text = footballPlayer.Birthday.ToString();
            tbAward.Text = footballPlayer.Award;
            tboxOriginCountry.Text = footballPlayer.OriginCountry;
            cboxTeamTitle.SelectedValue = footballPlayer.FootballTeamId;
            BtnDelete.Visibility = Visibility.Visible;
            BtnUpdate.Visibility = Visibility.Visible;
            tboxPlayerId.IsEnabled = false;
        }
        
        private void LoadBlankData()
        {
            tboxPlayerId.Text = "";
            tboxPlayerName.Text = "";
            tboxAchievement.Text = "";
            dateBirthday.Text = "";
            tbAward.Text = "";
            tboxOriginCountry.Text = "";
            cboxTeamTitle.SelectedIndex = 0;
            BtnAdd.Visibility = Visibility.Visible;
        }

        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            FootballPlayer footballPlayer = new FootballPlayer();
            footballPlayer.PlayerId = tboxPlayerId.Text;
            if (ExistedPlayerId(footballPlayer.PlayerId))
            {
                MessageBox.Show("Player Id existed");
                return;
            }
            footballPlayer.PlayerName = tboxPlayerName.Text;
            if (!IsValidName(footballPlayer.PlayerName))
            {
                MessageBox.Show("Invalid name");
                return;
            }
            footballPlayer.Achievements = tboxAchievement.Text;
            footballPlayer.Birthday = DateTime.Parse(dateBirthday.Text);
            if (footballPlayer.Birthday > new DateTime(2004, 1, 1))
            {
                MessageBox.Show("We only accept players born before 2004");
                return;
            }
            footballPlayer.Award = tbAward.Text;
            footballPlayer.OriginCountry = tboxOriginCountry.Text;
            footballPlayer.FootballTeamId = cboxTeamTitle.SelectedValue.ToString();
            
            
            _footballPlayerRepository.AddFootballPlayer(footballPlayer);
            
            
            if (_footballPlayerRepository.GetFootballPlayerList().Contains(footballPlayer))
            {
                MessageBox.Show("Add successfully");
                this.DialogResult = true;
                
            }
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
            updatePlayer.PlayerName = tboxPlayerName.Text;
            updatePlayer.Achievements = tboxAchievement.Text;
            updatePlayer.Birthday = DateTime.Parse(dateBirthday.Text);
            updatePlayer.Award = tbAward.Text;
            updatePlayer.OriginCountry = tboxOriginCountry.Text;
            updatePlayer.FootballTeamId = cboxTeamTitle.SelectedValue.ToString();
            _footballPlayerRepository.UpdateFootballPlayer(updatePlayer);
            if (_footballPlayerRepository.GetFootballPlayerList().Contains(updatePlayer))
            {
                MessageBox.Show("Update successfully");
                this.DialogResult = true;
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
                this.DialogResult = true;
            }
        }
    }
}
