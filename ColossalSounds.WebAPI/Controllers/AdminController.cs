using ColossalSounds.Data;
using ColossalSounds.WebAPI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ColossalSounds.WebAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/Admin")]
    public class AdminController : ApiController
    {
        [HttpPost]
        [Route("Register")]
        public IHttpActionResult CreateAdminAccount(RegisterBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newAdminUser = new ApplicationUser() { UserName = model.Email, Email = model.Email };
            var userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var userCreationResult = userManager.Create(newAdminUser, model.Password);
            if (userCreationResult.Succeeded)
            {
                var roleSetResult = userManager.AddToRole(newAdminUser.Id, Roles.Admin);
                if (!roleSetResult.Succeeded)
                {
                    return InternalServerError(new Exception("Role could not be assigned."));
                }
            }
            else
            {
                return BadRequest(userCreationResult.Errors.ToString());
            }
            return Ok();
        }
        [HttpPut]
        [Route("ToggleAdmin")]
        public IHttpActionResult ToggleAdminRole(string userEmail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            using (var ctx = new ApplicationDbContext())
            {
                var currentRole = RoleGetter(userEmail);
                var user = userManager.FindByEmail(userEmail);
                if (currentRole == "This model is invalid")
                {
                    return BadRequest(ModelState);
                }
                else if(currentRole == "Admin")
                {
                    userManager.RemoveFromRole(user.Id, Roles.Admin);
                    userManager.AddToRole(user.Id, Roles.User);
                    return Ok("This user has been set to the role of User");
                }
                else if(currentRole == "User")
                {
                    userManager.RemoveFromRole(user.Id, Roles.User);
                    userManager.AddToRole(user.Id, Roles.Admin);
                    return Ok("This user has been set to the role of Admin");
                }
                return InternalServerError();
            }
        }
        public string RoleGetter(string email)
        {
            if (!ModelState.IsValid)
            {
                return "This model is invalid";
            }
            var userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            using (var ctx = new ApplicationDbContext())
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(ctx));
                var user = userManager.FindByEmail(email);
                bool userIsAdmin = userManager.IsInRole(user.Id, Roles.Admin);
                string currentRole = (userIsAdmin) ? Roles.Admin : Roles.User;
                return currentRole;
            }
        }

        [OverrideAuthentication]
        [HttpGet]
        [Route("GetRole/{userEmail}/")]
        public IHttpActionResult GetRole(string userEmail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            using (var ctx = new ApplicationDbContext())
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(ctx));
                var user = userManager.FindByEmail(userEmail);
                bool userIsAdmin = userManager.IsInRole(user.Id, Roles.Admin);
                string currentRole = (userIsAdmin) ? Roles.Admin : Roles.User;
                return Ok($"{currentRole}");
            }
        }
    }
}
