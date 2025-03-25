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
    public enum Request { Vacation, Illness }
    public class Vacations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }    
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Request Request { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; } // מפתח זר
        public User User { get; set; } // ניווט ל-User
    }
}
