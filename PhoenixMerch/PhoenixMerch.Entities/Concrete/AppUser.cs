using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoenixMerch.Entities.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public Customer Customer { get; set; }
    }
}
