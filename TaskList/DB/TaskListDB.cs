namespace TaskList.DB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TaskListDB : DbContext
    {
        public TaskListDB()
            : base("name=TaskListDB")
        {
        }

        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.TasksAssignedFrom)
                .WithRequired(e => e.UserFrom)
                .HasForeignKey(e => e.IDFrom)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TasksAssignedTo)
                .WithRequired(e => e.UserTo)
                .HasForeignKey(e => e.IDTo)
                .WillCascadeOnDelete(false);
        }
    }
}
