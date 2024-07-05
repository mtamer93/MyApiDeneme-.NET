using Microsoft.EntityFrameworkCore;
using MyApiDeneme.Core.Entities;
using MyApiDeneme.DAL.Context;
using MyApiDeneme.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiDeneme.BLL
{
    public class AuthService : IAuthService
    {
        private readonly NorthwindDbContext _db;

        public AuthService(NorthwindDbContext db)
        {
            _db = db;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var user = await _db.Users.FirstOrDefaultAsync(a => a.Username == username);

            if (user == null)
            {
                return false; // Kullanıcı bulunamazsa false döner
            }

            if (!PasswordHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return false; // Şifre doğrulanamazsa false döner
            }

            return true; // Kullanıcı ve şifre doğrulandıysa true döne
        }

        public async Task<bool> RegisterAsync(string username, string password)
        {
            if (await UserExists(username))
            {
                return false; // Kullanıcı zaten varsa false döner
            }

            byte[] passwordHash, passwordSalt;
            PasswordHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var newUser = new Users
            {
                Username = username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            _db.Users.Add(newUser);
            await _db.SaveChangesAsync();

            return true; // Kullanıcı başarıyla kaydedildiyse true döner
        }

        private async Task<bool> UserExists(string username)
        {
            return await _db.Users.AnyAsync(a => a.Username == username);
        }
    }
}
