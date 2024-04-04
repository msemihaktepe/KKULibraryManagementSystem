using Library.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entity.Concrete
{
    public class Message : IEntity
    {
        public int MessageID { get; set; }
        public string? MessageText { get; set; }
        public DateTime MessageDate { get; set; }              
        public int UserID { get; set; }
        public User? User { get; set; }
        public bool MessageStatus { get; set; }


    }
}
