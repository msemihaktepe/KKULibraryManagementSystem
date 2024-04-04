using Library.Entity.Concrete;
using Type = Library.Entity.Concrete.Type;

namespace Library.WebUI.Models
{
    public class TypeViewModel
    {
        public Type Type { get; set; }
        public List<Type> Types { get; set; }
        public List<TypeWithBookModel> TypeWithBooks { get; set; }
    }
}
