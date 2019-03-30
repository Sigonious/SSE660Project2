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

namespace RiotAPI
{
    /// <summary>
    /// Interaction logic for MatchDetailsPage.xaml
    /// </summary>
    public partial class MatchDetailsPage : UserControl
    {
        GlobalClass global;

        public MatchDetailsPage()
        {
            InitializeComponent();
        }

        public MatchDetailsPage(GlobalClass global)
        {
            InitializeComponent();
            this.global = global;
        }

        public void LoadMatch(MatchDto match)
        {
            for (int i = 1; i <= 10; i++)
            {
                PlayerStats currentStats = match.participants[i - 1].stats;

                Grid currentGrid = (MainGrid.Children[i] as Grid);
                ((currentGrid.Children[0] as Viewbox).Child as Label).Content = match.participantIdentities[i - 1].player.summonerName;

                Label l1 = new Label();
                Grid.SetColumn(l1, 1);
                Grid.SetRow(l1, 1);
                l1.Content = currentStats.kills;
                l1.FontSize = 14;
                l1.Foreground = Brushes.White;

                Label l2 = new Label();
                Grid.SetColumn(l2, 2);
                Grid.SetRow(l2, 1);
                l2.Content = currentStats.deaths;
                l2.FontSize = 14;
                l2.Foreground = Brushes.White;

                Label l3 = new Label();
                Grid.SetColumn(l3, 3);
                Grid.SetRow(l3, 1);
                l3.Content = currentStats.assists;
                l3.FontSize = 14;
                l3.Foreground = Brushes.White;

                Label l4 = new Label();
                Grid.SetColumn(l4, 4);
                Grid.SetRow(l4, 1);
                l4.Content = currentStats.goldEarned;
                l4.FontSize = 14;
                l4.Foreground = Brushes.White;

                Label l5 = new Label();
                Grid.SetColumn(l5, 5);
                Grid.SetRow(l5, 1);
                l5.Content = currentStats.totalDamageDealtToChampions;
                l5.FontSize = 14;
                l5.Foreground = Brushes.White;

                currentGrid.Children.Add(l1);
                currentGrid.Children.Add(l2);
                currentGrid.Children.Add(l3);
                currentGrid.Children.Add(l4);
                currentGrid.Children.Add(l5);
            }
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            global.mainWindow.SetNewContent(1);
        }
    }
}
