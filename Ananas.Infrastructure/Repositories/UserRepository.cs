using Ananas.Core.Interfaces;
using Ananas.Core.Models;
using Ananas.Infrastructure.Common;
using Ananas.Infrastructure.Contexts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananas.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AnanasDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override Task Add(User entity)
        {
            throw new NotImplementedException();
        }


        public override void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public override void Update(User entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async Task<User> GetById(int id)
        {
            try
            {
                // Get Data User from Database by User Id
                var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
           
                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// CheckUserByEmail
        /// </summary>
        /// <param name="email"></param>
        /// <returns>User</returns>
        public async Task<User> CheckUserByEmail(string email)
        {
            try
            {
                // Get user from database by email
                var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Email.Equals(email));

                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// CheckUserByUserNameAndPassword
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>User</returns>
        public async Task<User> CheckUserByUserNameAndPassword(string userName, string password)
        {
            try
            {
                var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.UserName.Equals(userName) && u.Password.Equals(password));

                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
