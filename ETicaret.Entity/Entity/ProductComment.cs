using ETicaret.Entity.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETicaret.Entity.Entity
{
    [Table("ProductComment")]
    public class ProductComment : EntityBase
    {
        private string _content;

        [MaxLength(350, ErrorMessage = "İçerik 350 karakteri geçemez!")]
        [Required]
        [Column(Order = 3)]
        public string Content { get => _content; set => _content = value; }
        public int ProductId { get; set; }
        public string UserId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("UserId")]
        public virtual AppUser AppUser { get; set; }
    }
}
