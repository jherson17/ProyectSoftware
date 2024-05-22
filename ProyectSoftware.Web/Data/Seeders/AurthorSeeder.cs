using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using ProyectSoftware.Web.Data.Entities;

namespace ProyectSoftware.Web.Data.Seeders
{
    public class AurthorSeeder
    {
        private readonly DataContext _context;

        public AurthorSeeder(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            List<Author> authors = new List<Author>
                {
                    new Author { Name = "antonio" },
                    new Author { Name = "lucia" },
                };

            foreach (Author author in authors)
            {
                bool exists = await _context.Authors.AnyAsync(s => s.Name == author.Name);

                if (!exists)
                {
                    await _context.Authors.AddAsync(author);  // This should be genderType, not gendertype.
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}

