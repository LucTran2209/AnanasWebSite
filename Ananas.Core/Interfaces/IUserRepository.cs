using Ananas.Core.Common;
using Ananas.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananas.Core.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        /// <summary>
        /// CheckUserByEmail when Login by google account
        /// </summary>
        /// <param name="email"></param>
        /// <returns>User</returns>
        /// Create by: Trần Đình Lực
        /// Create at: 04.07.0204
        Task<User> CheckUserByEmail(string email);

        /// <summary>
        /// Check User By UserName And Password
        /// </summary>
        /// <param name="email"></param>
        /// <returns>User</returns>
        /// Create by: Trần Đình Lực
        /// Create at: 04.07.0204
        Task<User> CheckUserByUserNameAndPassword(string userName, string password);
    }
}
