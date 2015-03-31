using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuoteSystem.Identity
{
    public class UserStore<TUser> : IUserStore<TUser> where TUser : IdentityUser
    {
        public UserStore()
        {
            
        }
        
        public System.Threading.Tasks.Task CreateAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task DeleteAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<TUser> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<TUser> FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task UpdateAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}