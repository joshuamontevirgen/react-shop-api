using System.Collections.Generic;

namespace WebApplication3.tempDB
{
    public class UserAddresses
    {
        public static List<UserAddress> _userAddresses = new List<UserAddress>
        {
            new UserAddress { UserId = 1, Id=1, Address="address1", City="city1", ZipCode="1111" },
            new UserAddress { UserId = 1, Id=2, Address="address2", City="city2", ZipCode="2222" },
            new UserAddress { UserId = 1, Id=3, Address="address3", City="city3", ZipCode="333" },
            new UserAddress { UserId = 1, Id=4, Address="address4", City="city4", ZipCode="4444" },
            new UserAddress { UserId = 1, Id=5, Address="address5", City="city5", ZipCode="5555" },
            //new UserAddress { UserId = 1, Id=6, Address="address6", City="city6", ZipCode="6666" },
            //new UserAddress { UserId = 1, Id=7, Address="address7", City="city7", ZipCode="7777" },
            //new UserAddress { UserId = 1, Id=8, Address="address8", City="city8", ZipCode="8888" },
            //new UserAddress { UserId = 1, Id=9, Address="address9", City="city9", ZipCode="9999" },
        };
    }
}
