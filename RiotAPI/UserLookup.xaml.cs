using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace RiotAPI
{
    /// <summary>
    /// Interaction logic for UserLookup.xaml
    /// </summary>
    public partial class UserLookup : UserControl
    {
        private DependencyProperty UserInputSummonerNameProperty = DependencyProperty.Register("UserInputSummonerName", typeof(string), typeof(UserLookup), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public string UserInputSummonerName { get => (string)GetValue(UserInputSummonerNameProperty); set => SetValue(UserInputSummonerNameProperty, value); }

        GlobalClass global;

        public UserLookup(GlobalClass global)
        {
            InitializeComponent();
            this.global = global;

            DirectoryInfo directInfo = new DirectoryInfo(APIurls.SavedFilesDirectory);
            FileInfo[] files = directInfo.GetFiles("*.txt");

            foreach(FileInfo fi in files)
            {
                Viewbox newView = new Viewbox();
                Label newLabel = new Label();
                newView.Tag = fi.FullName;
                newLabel.Content = fi.Name;
                newView.Child = newLabel;

                OfflineResults.Items.Add(newView);
            }

            if(OfflineResults.Items.Count > 0)
            {
                OfflineResults.SelectedIndex = 0;
            }
        }

        public async void SearchButtonClick(object sender, RoutedEventArgs e)
        {
            if(UserInputSummonerName.Length < 3)
            {
                UserInputSummonerName = "Name must be at least 3 characters long.";
                return;
            }

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(APIurls.SummonerLookupURL + UserInputSummonerName + global.APIKey);
            global.APIcalls++;
            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch(Exception)
            {
                UserInputSummonerName = "Invalid name.";
                return;
            }
            
            string receiveData = await response.Content.ReadAsStringAsync();
            global.summoner = JsonConvert.DeserializeObject<Summoner>(receiveData);

            response = await client.GetAsync(APIurls.MatchListURL + global.summoner.accountID + global.APIKey);
            global.APIcalls++;
            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                UserInputSummonerName = "Invalid name.";
                return;
            }
            receiveData = await response.Content.ReadAsStringAsync();

            MatchlistDto heheXD = JsonConvert.DeserializeObject<MatchlistDto>(receiveData);

            global.matches = heheXD.matches;
            global.matchListPage.Update();
            global.mainWindow.SetNewContent(1);
        }

        public void ClearButtonClick(object sender, RoutedEventArgs e)
        {
            UserInputSummonerName = "";
        }

        public void OfflineButtonClick(object sender, RoutedEventArgs e)
        {
            if(!System.IO.File.Exists((string)(OfflineResults.Items[OfflineResults.SelectedIndex] as Viewbox).Tag))
            {
                UserInputSummonerName = "Invalid value.";
                return;
            }
            global.summoner.name = ((OfflineResults.Items[OfflineResults.SelectedIndex] as Viewbox).Child as Label).Content.ToString().Replace(".txt", "");
            global.matchListPage.OfflineMatches();
            global.mainWindow.SetNewContent(1);
        }
    }
}
