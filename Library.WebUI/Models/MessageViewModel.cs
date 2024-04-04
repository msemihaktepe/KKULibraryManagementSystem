using Library.Entity.Concrete;

namespace Library.WebUI.Models
{
    public class MessageViewModel
    {
        public Message Message { get; set; }
        public List<Message> Messages { get; set; }
    }
}
