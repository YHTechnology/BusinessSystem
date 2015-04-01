using Microsoft.AspNet.Identity;
using QuoteSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuoteSystem.Identity
{
    public class UserStore<TUser> : IUserStore<TUser> where TUser : IdentityUser
    {
        private BusnessSystemDBContext _BusnessSystemDBContext { get; set; }

        public UserStore()
        {
            _BusnessSystemDBContext = BusnessSystemDBContext.Create();
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
            BS.Entities.User lUser = _BusnessSystemDBContext.Users.Where(e => e.UserName == userId).First();

            if (lUser != null)
            {
                TUser lTUser = (TUser)Activator.CreateInstance(typeof(TUser));
                lTUser.Id = lUser.UserName;
                lTUser.UserName = lUser.UserName;
                lTUser.UserCName = lUser.UserCName;
                return System.Threading.Tasks.Task.FromResult<TUser>(lTUser);
            }

            return System.Threading.Tasks.Task.FromResult<TUser>(null);

            //throw new NotImplementedException();
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
          //throw new NotImplementedException();
        }
    }
}