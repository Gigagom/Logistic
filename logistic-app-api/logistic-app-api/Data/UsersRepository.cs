using logistic_app_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Data
{
    public class UsersRepository : IRepository<User>
    {
        private readonly LogisticContext _context;

        public UsersRepository(LogisticContext context)
        {
            _context = context;
        }

        public void Create(User item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _context.Users.Add(item);
        }

        public void Delete(User item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _context.Users.Remove(item);
        }

        public IEnumerable<User> GetAll()
        {
            var _users = _context.Users.Include(u=>u.User_position).ToList();
            return _users;
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(t => t.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(User item)
        {
            //nothing
        }
    }
}
