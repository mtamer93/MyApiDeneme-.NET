using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiDeneme.BLL
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(string username, string password);
        Task<bool> LoginAsync(string username, string password);
    }
}
