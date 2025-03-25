using Clean.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Data.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name {  get; set; }
        public string Role{  get; set; }
        public string Email {  get; set; }
        public string Password {  get; set; }
        public List<WorkingHours> WorkingHours { get; set; } = new List<WorkingHours>();
        public List<Vacations> Vacations { get; set; } = new List<Vacations>();

    }
}
