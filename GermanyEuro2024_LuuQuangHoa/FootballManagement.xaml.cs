using GermanyEuro2024_BusinessObject;
using GermanyEuro2024_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for FootballManagement.xaml
    /// </summary>
    public partial class FootballManagement : Page
    {
        private int? role = 0;
        private FootballPlayerRepository _footballPlayerRepository;
        private FootballTeamRepository _footballTeamRepository;
        public FootballManagement()
        {
            InitializeComponent();
            _footballPlayerRepository = new FootballPlayerRepository();
            _footballTeamRepository = new FootballTeamRepository();
        }

        public FootballManagement(int? role)
        {
            InitializeComponent();
            _footballPlayerRepository = new FootballPlayerRepository();
            _footballTeamRepository = new FootballTeamRepository();
            this.role = role;
            switch (role)
            {
                case 1:
                case 2:
                case 4:
                    DisableAllButton();
                    break;
                case 3:
                    break;
                default:
                    break;

            }

        }

        private void DisableAllButton()
        {
            ForceCursor = true;
            btn_add.IsEnabled = false;
            btn_delete.IsEnabled = false;
            btn_update.IsEnabled = false;
            tbox_search.IsEnabled = false;
            btn_search.IsEnabled = false;
            rbtn_byName.IsEnabled = false;
            rbtn_byAchievement.IsEnabled = false;
        }

        public void Page_Loaded(object sender, RoutedEventArgs e)
        {
            loadDataInit();
        }

        private void loadDataInit()
        {
            List<FootballTeam> footballTeams = _footballTeamRepository.GetAllTeams();
            List<FootballPlayer> footballPlayers = _footballPlayerRepository.GetFootballPlayerList();
            this.dtg_footballPlayerInformation.ItemsSource = footballPlayers;
            foreach(FootballPlayer footballPlayer in footballPlayers)
            {
                footballPlayer.FootballTeam = footballTeams.FirstOrDefault(m => m.FootballTeamId.Equals(footballPlayer.FootballTeamId));
            }
            this.cbbox_teamTitle.ItemsSource = _footballTeamRepository.GetAllTeams();
            this.cbbox_teamTitle.DisplayMemberPath = "TeamTitle";
            this.cbbox_teamTitle.SelectedValuePath = "FootballTeamId";
            tbox_playerId.Text = "";
            tbox_playerName.Text = "";
            tbox_achivements.Text = "";
            tbox_award.Text = "";
            tbox_country.Text = "";
            date_birthday.Text = "";


        }

        private void dtg_footballPlayerInformation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator
                                                    .ContainerFromIndex(dataGrid.SelectedIndex);
            if (row != null)
            {


                DataGridCell column = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
                string id = ((TextBlock)column.Content).Text;
                FootballPlayer footballPlayer = _footballPlayerRepository.GetFootballPlayerById(id);
                
                if(footballPlayer != null)
                {
                    this.tbox_playerId.IsEnabled = false;
                    this.tbox_playerId.IsReadOnly = true;
                    ForceCursor = true;
                    tbox_playerId.Cursor = Cursors.No;
                    this.tbox_playerId.Text = footballPlayer.PlayerId;
                    this.tbox_playerName.Text = footballPlayer.PlayerName;
                    this.tbox_achivements.Text = footballPlayer.Achievements;
                    this.tbox_award.Text = footballPlayer.Award;
                    this.cbbox_teamTitle.SelectedValue = footballPlayer.FootballTeamId;
                    this.tbox_country.Text = footballPlayer.OriginCountry;
                    this.date_birthday.Text = footballPlayer.Birthday.ToString();
                }
            }
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to delete this player?", "Delete", MessageBoxButton.YesNo);
            if(result == MessageBoxResult.Yes)
            {
                _footballPlayerRepository.RemoveFootballPlayer(tbox_playerId.Text);
                loadDataInit();
            }
            

        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            string id = tbox_playerId.Text;
            FootballPlayer updateFootballPlayer = _footballPlayerRepository.GetFootballPlayerById(id);
            updateFootballPlayer.PlayerName = tbox_playerName.Text;
            updateFootballPlayer.Achievements = tbox_achivements.Text;
            updateFootballPlayer.Award = tbox_award.Text;
            updateFootballPlayer.FootballTeamId = cbbox_teamTitle.SelectedValue.ToString();
            updateFootballPlayer.OriginCountry = tbox_country.Text;
            _footballPlayerRepository.UpdateFootballPlayer(updateFootballPlayer);
            loadDataInit();

        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            FootballPlayer footballPlayer = new FootballPlayer();
            footballPlayer.PlayerId = tbox_playerId.Text;
            footballPlayer.PlayerName = tbox_playerName.Text;
            if (!IsValidName(footballPlayer.PlayerName))
            {
                MessageBox.Show("Invalid name");
                return;
            }
            footballPlayer.Achievements = tbox_achivements.Text;
            footballPlayer.Award = tbox_award.Text;
            footballPlayer.FootballTeamId = cbbox_teamTitle.SelectedValue.ToString();
            footballPlayer.OriginCountry = tbox_country.Text;
            footballPlayer.Birthday = DateTime.Parse(date_birthday.Text);
            if(footballPlayer.Birthday > new DateTime(2004,1,1))
            {
                MessageBox.Show("Player must be born before 2004");
                return;
            }
            List<TextBox> textBoxes = new List<TextBox>{ tbox_playerId, tbox_playerName, tbox_achivements, tbox_award, tbox_country };
            foreach (TextBox textBox in textBoxes)
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    MessageBox.Show("Please fill all the information");
                    return;
                }
            }
            try { _footballPlayerRepository.AddFootballPlayer(footballPlayer); }
            catch(Exception a)
            {
                MessageBox.Show(a.Message);
            }
           
            loadDataInit();

        }
        private bool IsValidName(string name)
        {
            bool result = true;
            if (name.Length < 3 || name.Length > 100)
            {
                result = false;
            }
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

            private void btn_search_Click(object sender, RoutedEventArgs e)
            {
            string searchValue = tbox_search.Text;
            if (string.IsNullOrEmpty(searchValue))
            {
                MessageBox.Show("Please enter search value");
            }
            else if (rbtn_byName.IsChecked == true)
            {
                List<FootballPlayer> footballPlayers = _footballPlayerRepository.FindFootballPlayersByName(searchValue);
                if (footballPlayers.Count == 0)
                {
                    MessageBox.Show("No result found");
                }
                else
                {
                    this.dtg_footballPlayerInformation.ItemsSource = footballPlayers;
                }
            }
            else if (rbtn_byAchievement.IsChecked == true)
            {
                List<FootballPlayer> footballPlayers = _footballPlayerRepository.FindFootballPlayersByAchievements(searchValue);
                if (footballPlayers.Count == 0)
                {
                    MessageBox.Show("No result found");
                }
                else
                {
                    this.dtg_footballPlayerInformation.ItemsSource = footballPlayers;
                }

            }
        }
    }
}
