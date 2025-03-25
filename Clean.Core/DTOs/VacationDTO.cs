using Clean.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.DTOs
{
    public class VacationDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Request Request { get; set; }
        public int UserId { get; set; } 
    }
}
