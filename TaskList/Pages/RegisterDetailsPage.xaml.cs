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
    /// Interaction logic for RegisterDetailsPage.xaml
    /// </summary>
    public partial class RegisterDetailsPage : Page
    {
        public RegisterDetailsPage()
        {
            InitializeComponent();
        }
        //Make 2nd constructor

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = new EnterPage();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            //check fiedls
            //register
            //show message box
            NavigationService.Content = new EnterPage();
        }
    }
}
