using Portal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Classes
{
    public class DatabaseHelper
    {
        private static DatabaseHelper instance;

        private readonly DbContext dbContext;

        private DatabaseHelper(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public static DatabaseHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    // Assuming you have a PortalDbContext class
                    instance = new DatabaseHelper(new PortalDbContext());
                }
                return instance;
            }
        }

        public User GetUserByEmail(string email)
        {
            return dbContext.Set<User>().SingleOrDefault(u => u.Email == email);
        }

        public bool AuthenticateUser(string email, string hashedPassword)
        {
            var user = GetUserByEmail(email);

            if (user != null && hashedPassword == user.PasswordHash)
            {
                return true;
            }
            return false;
        }
    }
}
