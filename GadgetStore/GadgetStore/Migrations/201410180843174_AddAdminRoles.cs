namespace GadgetStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Web.Security;
    using WebMatrix.WebData;
    
    public partial class AddAdminRoles : DbMigration
    {
        public override void Up()
        {
            WebSecurity.InitializeDatabaseConnection("GadgetEntities", "UserProfile", "UserId", "UserName", autoCreateTables: true);
            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;
            if (!roles.RoleExists("Admin"))
                roles.CreateRole("Admin");
            if (!roles.RoleExists("User"))
                roles.CreateRole("User");
            if (membership.GetUser("admin", false) == null)
            {
                Console.WriteLine("User doe snot exist");
                membership.CreateUserAndAccount("admin", "Password1!");
            }
            else
            {
                Console.WriteLine("User exist");
            }
            roles.AddUsersToRoles(new[] { "admin" }, new[] { "Admin" });

        }
        
        public override void Down()
        {
            Roles.DeleteRole("admin");
            Membership.DeleteUser("admin");
        }
    }
}
