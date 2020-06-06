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
using TaskList.Pages;

namespace TaskList
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    /// 


    enum taskLists
    {
        AllTasks,
        ActiveTasks,
        CompletedTasks,
        AssignedByMeTasks
    }
    public partial class MainPage : Page
    {
        private User user;
        ListBoxItem allTasks = new ListBoxItem();
        ListBoxItem activeTasks = new ListBoxItem();
        ListBoxItem completedTasks = new ListBoxItem();
        ListBoxItem assignedByMeTasks = new ListBoxItem();
        public MainPage()
        {
            InitializeComponent();

        }

        public MainPage(User user)
        {
            InitializeComponent();
            this.user = user;



            TaskListsLB.Items.Add(allTasks);
            TaskListsLB.Items.Add(activeTasks);
            TaskListsLB.Items.Add(completedTasks);
            if (user.IsManager) { TaskListsLB.Items.Add(assignedByMeTasks); }


        }

        private void MenuBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
