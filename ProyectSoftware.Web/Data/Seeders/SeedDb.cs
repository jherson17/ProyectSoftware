using System.Reflection.PortableExecutable;

namespace ProyectSoftware.Web.Data.Seeders
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await new AurthorSeeder(_context).SeedAsync();
            await new GenderTypeSeeder(_context).SeedAsync();
        }
    }
}
