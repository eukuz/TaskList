using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
    /// Interaction logic for RegisterDetailsPage.xaml
    /// </summary>
    public partial class RegisterDetailsPage : Page
    {
        private User user;
        private bool isUpdating = false;

        public RegisterDetailsPage()
        {
            InitializeComponent();

            user = new User();
        }

        public RegisterDetailsPage(User user)
        {
            InitializeComponent();
            this.user = user;

            HeaderTB.Text = "Изменить данные";
            LoginTB.Text = user.Login;
            PasswordTB.Text = user.Password;
            FirstNameTB.Text = user.FirstName;
            LastNameTB.Text = user.LastName;
            RegisterButton.Content = "Сохранить";


            isUpdating = true;
            
        }



        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTB.Text.Length == 0 || PasswordTB.Text.Length == 0 || FirstNameTB.Text.Length == 0 || LastNameTB.Text.Length == 0)
            {
                MessageBox.Show("Все поля должны быть заполнены!");
                return;
            }

            using (TaskListDB db = new TaskListDB())
            {

                if (db.Users.Where(u => u.Login == LoginTB.Text && u.ID != user.ID).FirstOrDefault() != null )
                {
                    MessageBox.Show("Придумайте другой логин, пользователь с таким логином уже существует!");
                    return;
                }

                user.Login = LoginTB.Text;
                user.Password = PasswordTB.Text;
                user.FirstName = FirstNameTB.Text;
                user.LastName = LastNameTB.Text;

                if (isUpdating)
                {
                    db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    db.Users.Add(user);
                }

                db.SaveChanges();
            }

            MessageBox.Show("Успешно!");
            NavigationService.GoBack();
        }
    }
}
