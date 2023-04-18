using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoToys.Models
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }
        public string Body { get; set; }
        public ApplicationUser User { get; set; }
        //public ApplicationUser Visitor { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
