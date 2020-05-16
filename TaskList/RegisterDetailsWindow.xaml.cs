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
    /// Interaction logic for RegisterDetailsWindow.xaml
    /// </summary>
    public partial class RegisterDetailsWindow : Window
    {
        public RegisterDetailsWindow()
        {
            InitializeComponent();
        }
        public RegisterDetailsWindow(User user, string header, string button)
        {
            InitializeComponent();
            this.HeaderTB.Text = header;
            this.RegisterButton.Content = button;
        }

        public void GetAUser()
        {
            //return a user
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
