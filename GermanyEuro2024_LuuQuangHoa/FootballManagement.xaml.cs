﻿using GermanyEuro2024_BusinessObject;
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
    /// Interaction logic for FootballManagement.xaml
    /// </summary>
    public partial class FootballManagement : Page
    {
        private FootballPlayerRepository _footballPlayerRepository;
        private FootballTeamRepository _footballTeamRepository;
        public FootballManagement()
        {
            InitializeComponent();
            _footballPlayerRepository = new FootballPlayerRepository();
            _footballTeamRepository = new FootballTeamRepository();
        }

        public void Page_Loaded(object sender, RoutedEventArgs e)
        {
            loadDataInit();
        }

        private void loadDataInit()
        {
            this.dtg_footballPlayerInformation.ItemsSource = _footballPlayerRepository.GetFootballPlayerList();
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

      
    }
}