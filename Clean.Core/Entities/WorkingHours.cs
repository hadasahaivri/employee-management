using Clean.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Entities
{
    public class WorkingHours
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date {  get; set; }
        public TimeSpan Entry {  get; set; }
        public TimeSpan Exit { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; } // מפתח זר
        public virtual User User { get; set; } // ניווט ל-User
    }
}
