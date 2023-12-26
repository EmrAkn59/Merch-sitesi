using PhoenixMerch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PhoenixMerch.Entities.Concrete
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Status { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Order> Orders { get; set; }
		public AppUser AppUser { get; set; }
    }
}
