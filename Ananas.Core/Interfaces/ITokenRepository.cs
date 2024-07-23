using Ananas.Core.Common;
using Ananas.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananas.Core.Interfaces
{
    public interface ITokenRepository : IGenericRepository<string>
    {
        /// <summary>
        /// GenerateAccessToken
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// Create by: Trần Đình Lực
        /// Create at: 04/07/2024
        string GenerateAccessToken(User user);

        /// <summary>
        /// RefreshToken
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        /// Create by: Trần Đình Lực
        /// Create at: 04/07/2024
        Task<string> RefreshToken(string accessToken);
    }
}
