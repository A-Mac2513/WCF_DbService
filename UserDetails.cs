using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfDbService
{
    [DataContract]
    public class UserDetails
    {
        string username = string.Empty;
        string password = string.Empty;
        string country = string.Empty;
        string email = string.Empty;

        [DataMember]
        public string UserName { get => username; set => username = value; }

        [DataMember]
        public string Password { get => password; set => password = value; }

        [DataMember]
        public string Country { get => country; set => country = value; }

        [DataMember]
        public string Email { get => email; set => email = value; }
    }
}