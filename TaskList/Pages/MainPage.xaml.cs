using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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

    class TaskListItem
    {
        public bool IsCompleted { get; set; }
        public string Name { get; set; }
        public string AssignedUser { get; set; }
        public string DueDate { get; set; }



        public TaskListItem(DB.Task task, bool isAssignedByMe)
        {
            Task = task;

            IsCompleted = task.IsCompleted;
            Name = task.Name;
            if (isAssignedByMe)
            {
                AssignedUser = $"{task.UserTo.FirstName} {task.UserTo.LastName}";

            }
            else
            {
                AssignedUser = $"{task.UserFrom.FirstName} {task.UserFrom.LastName}";

            }

            DueDate = task.DueDate.ToString();
        }
        public DB.Task Task { get; set; }
    }
    enum taskLists
    {
        AllTasks,
        ActiveTasks,
        CompletedTasks,
        AssignedByMeTasks
    }

    public partial class MainPage : Page
    {
        string LastListPicked;
        private User user;
        List<User> Users { get; set; }
        DB.Task LastSelectedTask { get; set; }

        public MainPage()
        {
            InitializeComponent();

        }

        public MainPage(User user)
        {
            InitializeComponent();
            this.user = user;

            if (!user.IsManager)
            {
                AssignedByMeTasks.Visibility = Visibility.Hidden;
                assignedCB.IsEnabled = false;
            }


            ActiveTasks.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            using (TaskListDB db = new TaskListDB())
            {
                Users = db.Users.ToList();
                DataContext = Users;
            }
        }
        public void UpdateLastList()
        {
            switch (LastListPicked)
            {
                case "AllTasks":
                    SelectedListNameTxt.Text = "Все задачи";
                    ShowAll();
                    break;
                case "ActiveTasks":
                    SelectedListNameTxt.Text = "Активные задачи";
                    ShowActive();
                    break;
                case "CompletedTasks":
                    SelectedListNameTxt.Text = "Выполненные задачи";
                    ShowCompleted();        
                    break;
                case "AssignedByMeTasks":
                    SelectedListNameTxt.Text = "Назначенные мной задачи";
                    ShowAssignedByMe();
                    break;

            }
        }
        private void ShowAll()
        {
            ListOfTasks.Items.Clear();

            using (TaskListDB db = new TaskListDB())
            {
                foreach (DB.Task task in db.Tasks.Where(t => t.IDTo == user.ID && t.IsCompleted == false))
                {

                    ListOfTasks.Items.Add(new TaskListItem(task, false));
                }
            }
        }
        private void ShowActive()
        {
            ListOfTasks.Items.Clear();

            using (TaskListDB db = new TaskListDB())
            {
                foreach (DB.Task task in db.Tasks.Where(t => t.IDTo == user.ID && t.IsActive == true))
                {
                    ListOfTasks.Items.Add(new TaskListItem(task, false));
                }
            }
        }
        private void ShowCompleted()
        {
            ListOfTasks.Items.Clear();

            using (TaskListDB db = new TaskListDB())
            {
                foreach (DB.Task task in db.Tasks.Where(t => t.IDTo == user.ID && t.IsCompleted == true))
                {
                    ListOfTasks.Items.Add(new TaskListItem(task,false));
                }
            }
        }
        private void ShowAssignedByMe()
        {
            ListOfTasks.Items.Clear();

            using (TaskListDB db = new TaskListDB())
            {
                foreach (DB.Task task in db.Tasks.Where(t => t.IDFrom == user.ID && t.IDTo != user.ID))
                {
                    ListOfTasks.Items.Add(new TaskListItem(task,true));
                }
            }
        }


        private void MenuBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ListBtn_Click(object sender, RoutedEventArgs e)
        {
            AllTasks.Background = new SolidColorBrush(Color.FromRgb(100, 181, 246));
            ActiveTasks.Background = new SolidColorBrush(Color.FromRgb(100, 181, 246));
            AssignedByMeTasks.Background = new SolidColorBrush(Color.FromRgb(100, 181, 246));
            CompletedTasks.Background = new SolidColorBrush(Color.FromRgb(100, 181, 246));

            (sender as Button).Background = new SolidColorBrush(Color.FromRgb(156, 195, 229));

            LastListPicked = (sender as Button).Name;

            UpdateLastList();
        }

        private void AddATask_Click(object sender, RoutedEventArgs e)
        {
            using (TaskListDB db = new TaskListDB())
            {
                db.Tasks.Add(new DB.Task
                {
                    Name = NewTaskName.Text,
                    IsActive = true,
                    IDFrom = user.ID,
                    IDTo = user.ID,
                    IsCompleted = false
                });
                db.SaveChanges();
            }

            ShowActive();
        }

        private void ListOfTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListOfTasks.SelectedItems.Count == 0)
            {
                return;
            }

            LastSelectedTask = ((sender as ListBox).SelectedItem as TaskListItem).Task;
            taskNameTB.Text = LastSelectedTask.Name;
            dueDateDP.SelectedDate = LastSelectedTask.DueDate;
            descriptionTB.Text = LastSelectedTask.Description;

            isActiveBtn.Content = LastSelectedTask.IsActive ? "Сделать неактивной" : "Сделать активной";
            isCompletedBtn.Content = LastSelectedTask.IsCompleted ? "Сделать невыполненной" : "Выполнить";

            using (TaskListDB db = new TaskListDB())
            {
                if (LastListPicked == "AssignedByMeTasks")
                {
                    assignedCB.SelectedValue = LastSelectedTask.IDTo;

                }
                else
                {
                    assignedCB.SelectedValue = LastSelectedTask.IDFrom;

                }
            }


        }

        private void isActiveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ListOfTasks.SelectedItems.Count == 0)
            {
                MessageBox.Show("Сначала выберите задачу!");
                return;
            }

            using (TaskListDB db = new TaskListDB())
            {
                LastSelectedTask.IsActive = !LastSelectedTask.IsActive;
                db.Entry(LastSelectedTask).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            UpdateLastList();
        }

        private void isCompletedBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ListOfTasks.SelectedItems.Count == 0)
            {
                MessageBox.Show("Сначала выберите задачу!");
                return;
            }

            using (TaskListDB db = new TaskListDB())
            {
                LastSelectedTask.IsCompleted = !LastSelectedTask.IsCompleted;
                db.Entry(LastSelectedTask).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            UpdateLastList();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ListOfTasks.SelectedItems.Count == 0)
            {
                MessageBox.Show("Сначала выберите задачу!");
                return;
            }

            LastSelectedTask.Name = taskNameTB.Text;
            LastSelectedTask.Description = descriptionTB.Text;
            LastSelectedTask.DueDate = dueDateDP.SelectedDate;

            using (TaskListDB db = new TaskListDB())
            {
                if (Convert.ToInt32(assignedCB.SelectedValue) != user.ID)
                {
                    DB.Task task = new DB.Task();
                    task.Name = LastSelectedTask.Name;
                    task.IDFrom = LastSelectedTask.IDFrom;
                    task.IDTo = Convert.ToInt32(assignedCB.SelectedValue);
                    task.IsActive = LastSelectedTask.IsActive;
                    task.IsCompleted = LastSelectedTask.IsCompleted;
                    task.DueDate = LastSelectedTask.DueDate;
                    task.Description = LastSelectedTask.Description;

                    db.Entry(LastSelectedTask).State = System.Data.Entity.EntityState.Deleted;
                    db.Tasks.Add(task);
                }
                else
                {
                    db.Entry(LastSelectedTask).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
            }
            UpdateLastList();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ListOfTasks.SelectedItems.Count == 0)
            {
                MessageBox.Show("Сначала выберите задачу!");
                return;
            }

            using (TaskListDB db = new TaskListDB())
            {
                db.Entry(LastSelectedTask).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
            UpdateLastList();

            taskNameTB.Text = "";
            dueDateDP.SelectedDate = null;
            descriptionTB.Text = "";

            using (TaskListDB db = new TaskListDB())
            {
                assignedCB.SelectedValue = user.ID;
            }
        }
    }
}
