using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Users
{
    public class UserContactDetails : BaseEntity
    {
        public int UserId { get; set; }
        public string MobileNumber { get; set; }
    }
}
