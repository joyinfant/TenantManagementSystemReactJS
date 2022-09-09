using System;
using System.Collections.Generic;
using System.Text;

namespace TMSReactJS_API_Models.Input
{
    public class UserDetails
    {
        public int UId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Role { get; set; }
        public Boolean Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public int city { get; set; }
        public int state { get; set; }

    }
}
