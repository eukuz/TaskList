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
    /// Interaction logic for EnterWindow.xaml
    /// </summary>
    public partial class EnterWindow : Window
    {
        public EnterWindow()
        {
            InitializeComponent();

            SetBlueTheme();
        }

        private void SetBlueTheme()
        {

            ResourceDictionary resourceDict = Application.LoadComponent(new Uri("BlueTheme.xaml", UriKind.Relative)) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void OpenRegisterWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            RegisterDetailsWindow registerDetails = new RegisterDetailsWindow();
            registerDetails.Owner = this;
            bool? result = registerDetails.ShowDialog();

            if (result == true)
            {
                
            }
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            
            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show();
            this.Close();
        }
    }
}
