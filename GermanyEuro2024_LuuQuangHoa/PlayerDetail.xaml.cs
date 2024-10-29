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
using System.Windows.Shapes;

namespace GermanyEuro2024_LuuQuangHoa
{
    /// <summary>
    /// Interaction logic for PlayerDetail.xaml
    /// </summary>
    public partial class PlayerDetail : Window
    {
        private FootballPlayerRepository _footballPlayerRepository;
        private string playerId;
        public PlayerDetail()
        {
            InitializeComponent();
        }
        public PlayerDetail(string playerID)
        {
            InitializeComponent();
            this.playerId = playerID;
            _footballPlayerRepository = new FootballPlayerRepository();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FootballPlayer footballPlayer = _footballPlayerRepository.GetFootballPlayerById(playerId);
            this.tboxPlayerId.Text = footballPlayer.PlayerId;
            this.tboxPlayerName.Text = footballPlayer.PlayerName;
            this.tboxAchievement.Text = footballPlayer.Achievements;
            this.dateBirthday.Text = footballPlayer.Birthday.ToString();
            this.tbAward.Text = footballPlayer.Award;
            this.tboxOriginCountry.Text = footballPlayer.OriginCountry;

        }
    }
}
