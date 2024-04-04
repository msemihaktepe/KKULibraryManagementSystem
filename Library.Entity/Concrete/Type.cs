using Library.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entity.Concrete
{
    public class Type : IEntity
    {
        public int TypeID { get; set; }
        public string? TypeName { get; set; }
        public bool TypeStatus { get; set; }
        public List<Book>? Books { get; set; }
    }
}
