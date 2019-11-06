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
    [Table("ProductEvaluation")]
    public class ProductEvaluation:EntityBase
    {
        private bool _like;
        private bool _disLike;

        [Required]
        [Column(Order = 3)]
        public bool Like { get => _like; set => _like = value; }
        [Required]
        [Column(Order = 4)]
        public bool DisLike { get => _disLike; set => _disLike = value; }

        public int ProductId { get; set; }
        public string UserId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("UserId")]
        public virtual AppUser AppUser { get; set; }
    }
}
