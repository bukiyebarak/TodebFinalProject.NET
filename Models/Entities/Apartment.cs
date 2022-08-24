using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class Apartment
    {
        [Key]
        public int Id { get; set; }
        public char Block { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; }
        public string Floor { get; set; }
        public int No { get; set; }
        public ApartmentStatus ApartmentStatus { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public Image Image { get; set; }
    }
}
