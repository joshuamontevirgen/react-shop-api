using Core.Domain.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Users
{
    internal class UserAddressEntity : UserAddress
    {
        [ForeignKey("UserId")]
        internal virtual User User { get; set; }
    }
}
