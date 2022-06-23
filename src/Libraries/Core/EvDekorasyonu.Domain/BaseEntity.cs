using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvDekorasyonu.Domain
{
    public class BaseEntity
    {
        public Guid Id
        {
            get { return _id; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                    _id = Guid.NewGuid();
                else
                    _id = value;
            }
        }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        protected BaseEntity()
        {
            _id = Guid.NewGuid();
        }

        private Guid _id;
    }
}
