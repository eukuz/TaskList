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
using TaskList.DB;

namespace TaskList.Pages
{
    /// <summary>
    /// Interaction logic for EnterPage.xaml
    /// </summary>
    public partial class EnterPage : Page
    {
        public EnterPage()
        {
            InitializeComponent();
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            using (TaskListDB db = new TaskListDB())
            {
                User user = db.Users.Where(u => u.Login == LoginTxt.Text && u.Password == PasswordTxt.Password).FirstOrDefault();
                if (user != null)
                {
                    NavigationService.Content = new MenuPage(user);
                }
                else
                {
                    MessageBox.Show("Пользователь с такой комбинацией логина и пароля не найден!");
                }
            }
            
            
            //ADD Auth
        }

        private void OpenRegisterWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = new RegisterDetailsPage();
        }
    }
}
