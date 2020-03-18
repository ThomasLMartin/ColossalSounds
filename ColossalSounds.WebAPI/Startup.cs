using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using ColossalSounds.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ColossalSounds.WebAPI.Startup))]

namespace ColossalSounds.WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            SeedRolesAndDefault();
        }
        private void SeedRolesAndDefault()
        {
            // add a appdbcontext for our managers to interact with
            var ctx = new ApplicationDbContext();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ctx));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(ctx));
           
            // the seed method will check if "Admin" role exists, if not it will create one
            if (!roleManager.RoleExists(Roles.Admin))
            {
                var userRole = new IdentityRole(Roles.Admin);
                roleManager.Create(userRole);
                // we will then create a user
                ApplicationUser kyle = new ApplicationUser();
                kyle.Email = "kyle@teammate.com";
                kyle.UserName = kyle.Email;
                string password = "goodFriend:)";
                userManager.Create(kyle, password);
                // we will then add that user to the Admin Role
                userManager.AddToRole(kyle.Id, Roles.Admin);
            }
            // we will then check if a "User" role exists 
            if (!roleManager.RoleExists(Roles.User))
            {
                // if it does not, we'll create a User Role
                var userRole = new IdentityRole(Roles.User);
                roleManager.Create(userRole);
            }
        }
    }
}
