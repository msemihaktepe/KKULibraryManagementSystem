using System.ComponentModel.DataAnnotations;

namespace Library.WebUI.Models
{
    public class BookImageViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Kitap İsmi Boş Bırakılmamalıdır.")]
        [MinLength(2, ErrorMessage = "Kitap İsmi Minimum 2 Karakterli Olmalıdır.")]
        public string Name { get; set; }        
        public int NumberOfPage { get; set; }

        [Required(ErrorMessage = "Kitap Görüntüsü Boş Bırakılmamalıdır.")]
        public IFormFile Image { get; set; }
        public int AuthorId { get; set; }
        public int TypeId { get; set; }
    }
}
