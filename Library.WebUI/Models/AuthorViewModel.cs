using Library.Entity.Concrete;

namespace Library.WebUI.Models
{
    public class AuthorViewModel
    {
        public Author Author { get; set; }
        public List<Author> Authors { get; set; }
        public List<AuthorWithBookModel> AuthorWithBooks { get; set; }
    }
}
