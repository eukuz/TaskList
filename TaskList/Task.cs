namespace TaskList
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Task")]
    public partial class Task
    {
        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        public string Description { get; set; }

        public int IDFrom { get; set; }

        public int IDTo { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsActive { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DueDate { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
