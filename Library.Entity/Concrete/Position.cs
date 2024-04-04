using Library.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entity.Concrete
{
    public class Position : IEntity
    {
        public int PositionID { get; set; }
        public string? PositionName { get; set; }
        public bool PositionStatus { get; set; }
        public List<User>? Users { get; set; }
    }
}
