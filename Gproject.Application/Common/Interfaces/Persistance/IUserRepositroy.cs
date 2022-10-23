using Gproject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Application.Common.Interfaces.Persistance
{
    public interface IUserRepositroy
    {
        User? GetUserByEmail(string Email);
        void AddUser(User user); 
    }
}
