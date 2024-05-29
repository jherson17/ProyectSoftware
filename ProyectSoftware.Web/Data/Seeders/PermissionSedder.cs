using ProyectSoftware.Web.Data.Entities;

namespace ProyectSoftware.Web.Data.Seeders
{
    public class PermissionSedder
    {
        private readonly DataContext _context;

        public PermissionSedder(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            List<Permission> authorpermissions = Authors();
            List<Permission> genertypepermissions = GenderTypes();
            List<Permission> userpermissions = Users();
            List<Permission> rolepermissions = Roles();
            List<Permission> permissions = new List<Permission>();
           

            foreach (Permission permission in permissions)
            {
                Permission? tmpPermission = _context.Permissions.Where(p => p.Name == permission.Name && p.Module == permission.Module)
                                                                .FirstOrDefault();
                if (tmpPermission is null)
                {
                    _context.Permissions.Add(permission);
                }
            }

            await _context.SaveChangesAsync();
        }

        private List<Permission> Roles()
        {
            List<Permission> list = new List<Permission>
            {
                
                new Permission { Name = "showRoles", Description = "Ver Roles", Module = "Roles" },
                new Permission { Name = "createRoles", Description = "Crear Roles", Module = "Roles" },
                new Permission { Name = "updateRoles", Description = "Editar Roles", Module = "Roles" },
                new Permission { Name = "deleteRoles", Description = "Eliminar Roles", Module = "Roles" },
            };
            return list;
        }
        private List<Permission> Users()
        {
            List<Permission> list = new List<Permission>
            {
                new Permission { Name = "showUsers", Description = "Ver Users", Module = "Users" },
                new Permission { Name = "createUsers", Description = "Crear Users", Module = "Users" },
                new Permission { Name = "updateUsers", Description = "Editar Users", Module = "Users" },
                new Permission { Name = "deleteUsers", Description = "Eliminar Users", Module = "Users" },
            };

            return list;
        }
       
        private List<Permission> GenderTypes()
        {
            List<Permission> list = new List<Permission>
            {
                new Permission { Name = "showGenderTypes", Description = "Ver GenderTypes", Module = "GenderTypes" },
                new Permission { Name = "createGenderTypes", Description = "Crear GenderTypes", Module = "GenderTypes" },
                new Permission { Name = "updateGenderTypes", Description = "Editar GenderTypes", Module = "GenderTypes" },
                new Permission { Name = "deleteGenderTypes", Description = "Eliminar GenderTypes", Module = "GenderTypes" },
            };

            return list;
        }
        private List<Permission> Authors()
        {
            List<Permission> list = new List<Permission>
            {
                
                new Permission { Name = "showAuthors", Description = "Ver Authors", Module = "Authors" },
                new Permission { Name = "createAuthors", Description = "Crear Authors", Module = "Authors" },
                new Permission { Name = "updateAuthors", Description = "Editar Authors", Module = "Authors" },
                new Permission { Name = "deleteAuthors", Description = "Eliminar Authors", Module = "Authors" },
            };
           

            return list;
        }
    }
}
