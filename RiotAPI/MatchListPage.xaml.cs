using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
    /// Interaction logic for MatchList.xaml
    /// </summary>
    public partial class MatchListPage : UserControl
    {
        private DependencyProperty MatchListSummonerNameProperty = DependencyProperty.Register("MatchListSummonerName", typeof(string), typeof(MatchListPage), new FrameworkPropertyMetadata("No Result", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        private string MatchListSummonerName { get => (string)GetValue(MatchListSummonerNameProperty); set => SetValue(MatchListSummonerNameProperty, value); }

        private DependencyProperty LoadingOpacityProperty = DependencyProperty.Register("LoadingOpacity", typeof(double), typeof(MatchListPage), new FrameworkPropertyMetadata((double)1, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        private double LoadingOpacity { get => (double)GetValue(LoadingOpacityProperty); set => SetValue(LoadingOpacityProperty, value); }

        private DependencyProperty LoadingProgressProperty = DependencyProperty.Register("LoadingProgress", typeof(double), typeof(MatchListPage), new FrameworkPropertyMetadata((double)0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        private double LoadingProgress { get => (double)GetValue(LoadingProgressProperty); set => SetValue(LoadingProgressProperty, value); }

        private DependencyProperty LoadingVisibilityProperty = DependencyProperty.Register("LoadingVisibility", typeof(Visibility), typeof(MatchListPage), new FrameworkPropertyMetadata(Visibility.Collapsed, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        private Visibility LoadingVisibility { get => (Visibility)GetValue(LoadingVisibilityProperty); set => SetValue(LoadingVisibilityProperty, value); }

        private DependencyProperty SaveVisibilityProperty = DependencyProperty.Register("SaveVisibility", typeof(Visibility), typeof(MatchListPage), new FrameworkPropertyMetadata(Visibility.Collapsed, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        private Visibility SaveVisibility { get => (Visibility)GetValue(SaveVisibilityProperty); set => SetValue(SaveVisibilityProperty, value); }

        GlobalClass global;

        public MatchListPage(GlobalClass global)
        {
            InitializeComponent();
            this.global = global;
            MatchListStack.Children.RemoveAt(0);
            SaveVisibility = Visibility.Collapsed;
        }

        public void Update()
        {
            Sumname.Content = global.summoner.name;
            RetrieveMatchList();
        }

        public async void RetrieveMatchList()
        {
            LoadingOpacity = 0.2;
            LoadingVisibility = Visibility.Visible;
            LoadingProgress = 0;
            for (int i = 0; i < 20; i++)
            {
                await Task.Delay(250); //Delay to not timeout API requests
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(APIurls.MatchURL + global.matches[i].gameId + global.APIKey);
                global.APIcalls++;
                response.EnsureSuccessStatusCode();
                string receiveData = await response.Content.ReadAsStringAsync();
                global.detailedMatches.Add(JsonConvert.DeserializeObject<MatchDto>(receiveData));
                LoadingProgress += 5;
            }
            LoadingOpacity = 1;
            LoadingVisibility = Visibility.Collapsed;

            UpdateMatchList();
        }

        public void UpdateMatchList()
        {
            for(int i = 0; i < 20 && i < global.detailedMatches.Count; i++)
            {
                ParticipantDto pdto= FindParticipant(global.detailedMatches[i]);

                Grid newGrid = new Grid();
                newGrid.Height = 80;
                ColumnDefinition cd1 = new ColumnDefinition();
                cd1.Width = new GridLength(71, GridUnitType.Star);
                ColumnDefinition cd2 = new ColumnDefinition();
                cd2.Width = new GridLength(25, GridUnitType.Star);
                ColumnDefinition cd3 = new ColumnDefinition();
                cd3.Width = new GridLength(104, GridUnitType.Star);
                ColumnDefinition cd4 = new ColumnDefinition();
                cd4.Width = new GridLength(9, GridUnitType.Star);
                ColumnDefinition cd5 = new ColumnDefinition();
                cd5.Width = new GridLength(111, GridUnitType.Star);
                newGrid.ColumnDefinitions.Add(cd1);
                newGrid.ColumnDefinitions.Add(cd2);
                newGrid.ColumnDefinitions.Add(cd3);
                newGrid.ColumnDefinitions.Add(cd4);
                newGrid.ColumnDefinitions.Add(cd5);

                RowDefinition rd1 = new RowDefinition();
                rd1.Height = new GridLength(15, GridUnitType.Star);
                RowDefinition rd2 = new RowDefinition();
                rd2.Height = new GridLength(11, GridUnitType.Star);
                RowDefinition rd3 = new RowDefinition();
                rd3.Height = new GridLength(14, GridUnitType.Star);
                newGrid.RowDefinitions.Add(rd1);
                newGrid.RowDefinitions.Add(rd2);
                newGrid.RowDefinitions.Add(rd3);

                Border b = new Border();
                b.BorderThickness = new Thickness(1);
                b.BorderBrush = Brushes.White;
                Grid.SetRowSpan(b, 3);
                Grid.SetColumnSpan(b, 5);

                Viewbox vb0 = new Viewbox();
                Grid.SetRowSpan(vb0, 3);

                TextBlock tb0 = new TextBlock();
                tb0.Text = "Match " + (i+1);
                tb0.Foreground = Brushes.White;
                vb0.Child = tb0;

                Viewbox vb1 = new Viewbox();
                Grid.SetColumn(vb1, 4);
                vb1.HorizontalAlignment = HorizontalAlignment.Left;

                TextBlock tb1 = new TextBlock();
                tb1.Foreground = Brushes.White;
                tb1.Text = pdto.championId.ToString();
                vb1.Child = tb1;

                Viewbox vb2 = new Viewbox();
                Grid.SetColumn(vb2, 4);
                Grid.SetRow(vb2, 1);
                vb2.HorizontalAlignment = HorizontalAlignment.Left;

                TextBlock tb2 = new TextBlock();
                tb2.Foreground = Brushes.White;
                tb2.Text = pdto.stats.kills.ToString() + "/" + pdto.stats.deaths.ToString() + "/" + pdto.stats.assists.ToString(); 
                vb2.Child = tb2;

                Viewbox vb3 = new Viewbox();
                Grid.SetColumn(vb3, 4);
                Grid.SetRow(vb3, 2);
                vb3.HorizontalAlignment = HorizontalAlignment.Left;

                TextBlock tb3 = new TextBlock();
                tb3.Foreground = Brushes.White;
                tb3.Text = pdto.stats.goldEarned.ToString();
                vb3.Child = tb3;

                Viewbox vb4 = new Viewbox();
                Grid.SetColumn(vb4, 2);
                Grid.SetRow(vb4, 0);
                vb4.HorizontalAlignment = HorizontalAlignment.Right;

                TextBlock tb4 = new TextBlock();
                tb4.Foreground = Brushes.White;
                tb4.Text = "Champion:";
                vb4.Child = tb4;

                Viewbox vb5 = new Viewbox();
                Grid.SetColumn(vb5, 2);
                Grid.SetRow(vb5, 1);
                vb5.HorizontalAlignment = HorizontalAlignment.Right;

                TextBlock tb5 = new TextBlock();
                tb5.Foreground = Brushes.White;
                tb5.Text = "KDA:";
                vb5.Child = tb5;

                Viewbox vb6 = new Viewbox();
                Grid.SetColumn(vb6, 2);
                Grid.SetRow(vb6, 2);
                vb6.HorizontalAlignment = HorizontalAlignment.Right;

                TextBlock tb6 = new TextBlock();
                tb6.Foreground = Brushes.White;
                tb6.Text = "Gold Earned:";
                vb6.Child = tb6;

                Button b1 = new Button();
                b1.Content = "Details";
                b1.Click += MatchDetailsButton;
                Grid.SetRow(b1, 2);

                newGrid.Children.Add(b);
                newGrid.Children.Add(vb0);
                newGrid.Children.Add(vb1);
                newGrid.Children.Add(vb2);
                newGrid.Children.Add(vb3);
                newGrid.Children.Add(vb4);
                newGrid.Children.Add(vb5);
                newGrid.Children.Add(vb6);
                newGrid.Children.Add(b1);

                MatchListStack.Children.Add(newGrid);
            }
            SaveVisibility = Visibility.Visible;
        }

        public ParticipantDto FindParticipant(MatchDto md)
        {
            int participantID = -1;
            foreach(ParticipantIdentityDto pi in md.participantIdentities)
            {
                if (pi.player.summonerName == global.summoner.name)
                {
                    participantID = pi.participantId;
                    break;
                }
            }
            if (participantID == -1)
                return null;


            foreach(ParticipantDto p in md.participants)
            {
                if(participantID == p.participantId)
                {
                    return p;
                }
            }
            return null;
        }

        public void MatchDetailsButton(object sender, RoutedEventArgs e)
        {
            int index = MatchListStack.Children.IndexOf(((sender as Button).Parent as Grid));
            global.matchDetails = new MatchDetailsPage(global);
            global.matchDetails.LoadMatch(global.detailedMatches[index]);
            global.mainWindow.SetNewContent(2);
        }

        public void SaveResultsButtonClick(object sender, RoutedEventArgs e)
        {
            string results = JsonConvert.SerializeObject(global.detailedMatches);
            System.IO.File.WriteAllText(APIurls.SavedFilesDirectory + global.summoner.name + ".txt", results);
        }

        public void LoadButtonClick(object sender, RoutedEventArgs e)
        {
            string loadedData = System.IO.File.ReadAllText(APIurls.SavedFilesDirectory + global.summoner.name + ".txt");
            global.detailedMatches = JsonConvert.DeserializeObject<List<MatchDto>>(loadedData);
            UpdateMatchList();
        }

        public void OfflineMatches()
        {
            try
            {
                string loadedData = System.IO.File.ReadAllText(APIurls.SavedFilesDirectory + global.summoner.name + ".txt");
                global.detailedMatches = JsonConvert.DeserializeObject<List<MatchDto>>(loadedData);
                UpdateMatchList();
                MatchListSummonerName = global.summoner.name;
            }
            catch(Exception)
            {
                global.errorPage.ErrorContent = "Could not find file.";
                global.mainWindow.SetNewContent(404);
            }
        }

        public void BackButtonClick(object sender, RoutedEventArgs e)
        {
            global.mainWindow.SetNewContent(0);
        }
    }
}
