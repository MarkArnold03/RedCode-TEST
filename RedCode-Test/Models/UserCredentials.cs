using System;
namespace RedCode_Test.Models
{
	public class UserCredentials
	{
        public static List<User> Users = new List<User>()
        {
            new User()
            {
                UserName = "marnold",
                Password = "Hej123",
            },
            new User()
            {
                UserName = "marco",
                Password = "mar123",
            }
        };
    }
}

