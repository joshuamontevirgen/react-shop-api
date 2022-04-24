using Core.Domain.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Users
{
    internal class UserContactDetailsEntity : UserContactDetails
    {
        [ForeignKey("UserId")]
        internal virtual User User { get; set; }
    }
}
