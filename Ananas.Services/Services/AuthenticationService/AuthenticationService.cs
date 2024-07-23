using Ananas.Core.Common;
using Ananas.Core.Models;
using Ananas.Services.Common.Base;
using Ananas.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananas.Services.Services.AuthenticationService
{
    public class AuthenticationService : BaseService, IAuthenticationService
    {
        public AuthenticationService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public Task<string> LoginByAccountGoogle(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<string> LoginByUserNameAndPassword(string userName, string password)
        {
            try
            {
                User user = await _unitOfWork.Users.CheckUserByUserNameAndPassword(userName, password);
                if (user == null)
                {
                    return null;
                }

                string accessToken =  _unitOfWork.Tokens.GenerateAccessToken(user);

                return accessToken;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
