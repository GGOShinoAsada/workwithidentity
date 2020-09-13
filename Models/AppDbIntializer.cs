using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace workwithidentity.Models
{
    public class AppDbIntializer:DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            #region Import Manager
            var UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            #endregion
            #region Roles Create
            var RoleAdmin = new IdentityRole { Name = "Admin" };
            var roleUser = new IdentityRole { Name = "User" };
            RoleManager.Create(RoleAdmin);
            RoleManager.Create(roleUser);

            #endregion
            #region User Creating
            var admin = new ApplicationUser { Email = "admin@gmail.com", UserName = "TestAdmin" };
            string pass = "Forsag#5School#46";
            var rezultadmin = UserManager.Create(admin, pass);
            if (rezultadmin.Succeeded)
            {
                UserManager.AddToRole(admin.Id, RoleAdmin.Name);
            }
            var user = new ApplicationUser { Email = "testuser@mail.ru", UserName = "Alex" };
            string pass2 = pass;
            var rezultuser = UserManager.Create(admin, pass2);
            if (rezultuser.Succeeded)
            {
                UserManager.AddToRole(user.Id, roleUser.Name);
            }
            #endregion
            base.Seed(context);
        }
    }
}