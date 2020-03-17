using System;
using System.Collections.Generic;
using System.Linq;
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
        }



        // set up a seed method in here
        // the seed method will check if "Admin" role exists, if not it will create one
        // we will then create a user
        // we will then add that user to the Admin Role
        // we will then check if a "User" role exists 
        // if it does not, we'll create a User Role

        // add a appdbcontext for our managers to interact with
      //  var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
       // var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
    }
}
