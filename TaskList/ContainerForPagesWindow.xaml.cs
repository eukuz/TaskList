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
using TaskList.Pages;

namespace TaskList
{
    /// <summary>
    /// Interaction logic for ContainerForPagesWindow.xaml
    /// </summary>
    public partial class ContainerForPagesWindow : Window
    {
        public ContainerForPagesWindow()
        {
            InitializeComponent();

            frameContainer.Content = new EnterPage();
        }
    }
}
