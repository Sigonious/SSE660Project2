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
    /// Interaction logic for ErrorPage.xaml
    /// </summary>
    public partial class ErrorPage : UserControl
    {
        private DependencyProperty ErrorContentNameProperty = DependencyProperty.Register("ErrorContent", typeof(string), typeof(ErrorPage), new FrameworkPropertyMetadata("Error Message Goes Here", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public string ErrorContent { get => (string)GetValue(ErrorContentNameProperty); set => SetValue(ErrorContentNameProperty, value); }

        public ErrorPage()
        {
            InitializeComponent();
        }
    }
}
