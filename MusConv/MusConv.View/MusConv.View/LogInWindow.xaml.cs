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
using MusConv.ModelView;

namespace MusConv.View
{
    /// <summary>
    /// Interaction logic for LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        public LogInWindow(MainWindowViewModel mainWindowViewModel)
        {
            InitializeComponent();
            DataContext = new LogInViewModel(mainWindowViewModel);
        }

        private void logInWebView_NavigationStarting(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs e)
        {
            (DataContext as LogInViewModel).OnNavigationStarting(this, e);
            
        }
    }
}
