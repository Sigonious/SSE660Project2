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
using System.Windows.Threading;

namespace RiotAPI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DependencyProperty CurrentContentProperty = DependencyProperty.Register("CurrentContent", typeof(UserControl), typeof(MainWindow), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        private UserControl CurrentContent { get => (UserControl)GetValue(CurrentContentProperty); set => SetValue(CurrentContentProperty, value); }

        DispatcherTimer apiCallChecker = new DispatcherTimer();
        int timerTicks = 0;

        public GlobalClass global = new GlobalClass();

        public MainWindow()
        {
            InitializeComponent();

            apiCallChecker.Interval = new TimeSpan(0, 0, 1);
            apiCallChecker.Tick += ApiCallChecker_Tick;

            global.mainWindow = this;
            global.errorPage = new ErrorPage();
            global.userLookup = new UserLookup(global);
            global.matchListPage = new MatchListPage(global);
            global.matchDetails = new MatchDetailsPage(global);

            if (!System.IO.File.Exists(@".\Resources\APIkey.txt"))
            {
                global.errorPage.ErrorContent = "Unable to locate API Key.";
                MainControl.Content = global.errorPage;
            }

            global.APIKey = System.IO.File.ReadAllText(@".\Resources\APIkey.txt");

            if(!global.APIKey.Contains("RGAPI"))
            {
                global.errorPage.ErrorContent = "Invalid API Key.";
                MainControl.Content = global.errorPage;
            }
            else
            {
                MainControl.Content = global.userLookup;
            }

        }

        private void ApiCallChecker_Tick(object sender, EventArgs e)
        {
            if(global.APIcalls == 20)
            {
                global.errorPage.ErrorContent = "Too many API calls.";
                MainControl.Content = global.errorPage;
            }

            if(timerTicks % 120 == 0)
            {
                timerTicks = 0;
                global.APIcalls = 0;
            }
            else
            {
                timerTicks++;
            }
        }

        public void SetNewContent(int state)
        {
            switch(state)
            {
                case 0:
                    //User Lookup
                    MainControl.Content = global.userLookup;
                    break;
                case 1:
                    //Match List Page
                    MainControl.Content = global.matchListPage;
                    break;
                case 2:
                    //Individual Match
                    MainControl.Content = global.matchDetails;
                    break;
                case 404:
                    MainControl.Content = global.errorPage;
                    break;
                default:
                    //Always default to user lookup
                    MainControl.Content = global.userLookup;
                    break;
            }
        }
    }
}
