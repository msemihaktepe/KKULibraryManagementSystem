using Library.Entity.Concrete;

namespace Library.WebUI.Models
{
    public class PositionViewModel
    {
        public Position Position { get; set; }
        public List<Position> Positions { get; set; }
        public List<PositionWithUserModel> PositionWithUsers { get; set; }
    }
}
