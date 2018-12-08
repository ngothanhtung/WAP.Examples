using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace OnlineShopMvcWeb.Models
{
    public class IdentityRoleManager: RoleManager<IdentityRole>
    {
        public IdentityRoleManager(IRoleStore<IdentityRole, string> roleStore) : base(roleStore)
        {

        }
        public static IdentityRoleManager Create(IdentityFactoryOptions<IdentityRoleManager> options, IOwinContext context)
        {
            return new IdentityRoleManager(new RoleStore<IdentityRole>(context.Get<ApplicationDbContext>()));
        }
    }
}