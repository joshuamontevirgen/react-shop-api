using Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Users
{
    internal class UserEntity : User
    {
        internal virtual List<UserAddressEntity> Addresses { get; set; }
        internal virtual UserContactDetailsEntity ContactDetails { get; set; }
    }
}
