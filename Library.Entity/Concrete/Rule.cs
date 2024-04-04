using Library.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entity.Concrete
{
    public class Rule : IEntity
    {
        public int RuleID { get; set; }
        public string? RuleDesc { get; set; }
        public bool RuleStatus { get; set; }
    }
}
