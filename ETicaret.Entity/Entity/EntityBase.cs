using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Entity.Entity
{
    public class EntityBase
    {
        private int _id;
        private DateTime _addedDate;
        private bool _isActive;

        [Column(Order = 0)]
        [Key]
        public int Id { get => _id; set => _id = value; }
        [Column(Order = 1)]
        public DateTime AddedDate { get => _addedDate; set => _addedDate = value; }
        [Column(Order = 2)]
        public bool IsActive { get => _isActive; set => _isActive = value; }
        public EntityBase()
        {
            AddedDate = DateTime.Now;
            IsActive = true;
        }
    }
}
