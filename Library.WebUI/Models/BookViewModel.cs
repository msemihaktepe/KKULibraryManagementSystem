using Library.Entity.Concrete;
using Type = Library.Entity.Concrete.Type;

namespace Library.WebUI.Models
{
    public class BookViewModel
    {
        public List<Book> Books { get; set; }
        public Book Book { get; set; }
        public BookImageViewModel ImageBook { get; set; }
        public List<AuthorWithFullNameModel> Authors { get; set; }
        public List<Type> Types { get; set; }
    }
}
