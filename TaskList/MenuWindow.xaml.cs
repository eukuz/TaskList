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

namespace TaskList
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        User user;
        public MenuWindow()
        {
            InitializeComponent();




            // DELETE IT
            this.user = new User();
        } 
        public MenuWindow(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void TaskListsBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            bool? result = mainWindow.ShowDialog();
        }

        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {
            EnterWindow enterWindow = new EnterWindow();
            enterWindow.Show();
            this.Close();
        }

        private void ChangeDataBtn_Click(object sender, RoutedEventArgs e)
        {
            RegisterDetailsWindow registerDetails = new RegisterDetailsWindow(user, "Изменить Данные","Сохранить" );
            registerDetails.Owner = this;

            bool? result = registerDetails.ShowDialog();

            if (result == true)
            {

            }
        }
    }
}
