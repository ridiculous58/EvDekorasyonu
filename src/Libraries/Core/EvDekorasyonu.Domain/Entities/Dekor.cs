using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvDekorasyonu.Domain.Entities
{
    public class Dekor : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Star { get; set; }
        public string ImageUrl { get; set; }
        public Guid DekorCategoryId { get; set; }
        public DekorCategory DekorCategory { get; set; }
    }
}
