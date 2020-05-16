namespace TaskList
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

        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Task)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IDFrom)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Task1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.IDTo)
                .WillCascadeOnDelete(false);
        }
    }
}
