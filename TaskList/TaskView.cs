using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TaskList
{
    class TaskView
    {
        Grid grid = new Grid();
        TaskView()
        {
            ColumnDefinition columnCB = new ColumnDefinition();
            ColumnDefinition columnTaskName = new ColumnDefinition();
            ColumnDefinition columnDueDate = new ColumnDefinition();
            ColumnDefinition columnAssigned = new ColumnDefinition();
            grid.ColumnDefinitions.Add(columnCB);
            grid.ColumnDefinitions.Add(columnTaskName);
            grid.ColumnDefinitions.Add(columnDueDate);
            grid.ColumnDefinitions.Add(columnAssigned);


        }
    }
}
