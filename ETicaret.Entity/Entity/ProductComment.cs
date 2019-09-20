using ETicaret.Entity.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Entity.Entity
{
    [Table("ProductComment")]
    public class ProductComment:EntityBase
    {
        private string _content;

        [MaxLength(350, ErrorMessage = "İçerik 350 karakteri geçemez!")]
        [Required]
        [Column(Order = 3)]
        public string Content { get => _content; set => _content = value; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
