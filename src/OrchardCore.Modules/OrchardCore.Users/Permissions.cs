using System.Collections.Generic;
using System.Threading.Tasks;
using OrchardCore.Security.Permissions;

namespace OrchardCore.Users
{
    public class Permissions : IPermissionProvider
    {
        public static readonly Permission ManageUsers = CommonPermissions.ManageUsers;
        public static readonly Permission ViewUsers = CommonPermissions.ViewUsers;

        public static readonly Permission ManageOwnUserInformation = new Permission("ManageOwnUserInformation", "Manage own user information", new Permission[] { ManageUsers });

        public Task<IEnumerable<Permission>> GetPermissionsAsync()
        {
            return Task.FromResult<IEnumerable<Permission>>(new List<Permission>
            {
                ManageUsers,
                ManageOwnUserInformation,
                ViewUsers,
            });
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes()
        {
            return new[] {
                new PermissionStereotype {
                    Name = "Administrator",
                    Permissions = new[] { ManageUsers }
                },
                new PermissionStereotype {
                    Name = "Editor",
                    Permissions = new[] { ManageOwnUserInformation }
                },
                new PermissionStereotype {
                    Name = "Moderator",
                    Permissions = new[] { ManageOwnUserInformation }
                },
                new PermissionStereotype {
                    Name = "Contributor",
                    Permissions = new[] { ManageOwnUserInformation }
                },
                new PermissionStereotype {
                    Name = "Author",
                    Permissions = new[] { ManageOwnUserInformation }
                }
            };
        }
    }
}
