using Microsoft.AspNet.Identity;
using System;

namespace QuoteSystem.Identity
{
    public class IdentityUser : IUser
    {
        public IdentityUser()
        {
            Id = Guid.NewGuid().ToString();
        }

        public IdentityUser(string userName)
            : this()
        {
            UserName = userName;
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string UserCName { get; set; }

        //public virtual string PasswordHash { get; set; }
        //public virtual string SecurityStamp { get; set; }
    }
}