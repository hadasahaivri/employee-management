using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.DTOs
{
    public class WorkingHoursDTO
    {
        public DateTime Date { get; set; }
        public DateTime Entry { get; set; }
        public DateTime Exit { get; set; }
        public int UserId { get; set; } 
    }
}
