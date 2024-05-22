using Microsoft.EntityFrameworkCore;
using ProyectSoftware.Web.Data.Entities;

namespace ProyectSoftware.Web.Data.Seeders
{
    public class UserSeeder
    {
        private readonly DataContext _context;

        public UserSeeder(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            List<User> useres = new List<User>
                {
                    new User { Name = "rodolfo" },
                    new User { Name = "carmen" },
                };

            foreach (User user in useres)
            {
                bool exists = await _context.Users.AnyAsync(s => s.Name == user.Name);

                if (!exists)
                {
                    await _context.Users.AddAsync(user);  // This should be genderType, not gendertype.
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
