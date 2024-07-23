using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananas.Services.Interfaces
{
    public interface IAuthenticationService
    {
        /// <summary>
        /// LoginByAccountGoogle
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        /// Create by: Trần Đình Lực
        /// Create at: 04.07.2024
        Task<string> LoginByAccountGoogle(string email);

        /// <summary>
        /// LoginByUserNameAndPassword
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// Create by: Trần Đình Lực
        /// Create at: 04.07.2024
        Task<string> LoginByUserNameAndPassword(string userName, string password);
        
    }
}
