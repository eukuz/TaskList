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

namespace TaskList.Pages
{
    /// <summary>
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void TaskListsBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = new MainPage();
        }

        private void ChangeDataBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = new RegisterDetailsPage(/* User */);
        }

        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = new EnterPage();
        }
    }
}
