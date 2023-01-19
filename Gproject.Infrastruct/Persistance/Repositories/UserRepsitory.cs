using Gproject.Application.Common.Interfaces.Persistance;
using Gproject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Infrastruct.Persistance.Repositories
{
    public class UserRepsitory : IUserRepositroy
    {
        private static readonly List<User> _users = new();
        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public User? GetUserByEmail(string Email)
        {
            return _users.FirstOrDefault(x => x.Email == Email);
        }
    }
}
