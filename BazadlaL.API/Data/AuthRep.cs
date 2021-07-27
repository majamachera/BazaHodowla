using System;
using System.Text;
using System.Threading.Tasks;
using BazadlaL.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BazadlaL.API.Data
{
    public class AuthRep : IAuthReposytory
    {
        private readonly DataContext _context;
        #region method public
        public AuthRep(DataContext context)
        {
            _context = context;
        }
        public async Task<User> Login(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Name == username);
            
            if (user == null )
            {
                return null;
            }
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            
                return null;

            return user;

        }

        

        public async Task<User> Register(User user, string password, string emaile)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHashSalt(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Email = emaile;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;

        }

      

        public async Task<bool> UserExist(string username)
        {
            if(await _context.Users.AnyAsync(x => x.Name == username))
               {
                    return true;
               }
               return false;
        }

       
        #endregion
        #region  method private
        private void CreatePasswordHashSalt(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
            
        }
         private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
         {
             using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
               
                var computed = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
               for (int i = 0; i < computed.Length; i++)
               {
                if (computed[i] != passwordHash[i])
                {
                        return false;
                 }  
                 
               }
               return true;
            }
        }
       #endregion

    }
}