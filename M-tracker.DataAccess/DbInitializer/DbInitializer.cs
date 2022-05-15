using M_tracker.DataAccess.Data;
using M_tracker.Models;
using M_tracker.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_tracker.DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDataContext _db;
        public DbInitializer(
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager,
        ApplicationDataContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }
        public void Initialize()
        {
            //migrations if they are not applied
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {

            }

            //create roles if they are not created
            if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer)).GetAwaiter().GetResult();


                //if roles are not created, then we will create admin user as well

                //_userManager.CreateAsync(new  ApplicationUser
                //{
                //    UserName = "adminashan",
                //    Email = "adminashan@gmail.com",
                //    Name = "admin",
                //    PhoneNumber = "1112223333",
                //    StreetAddress = "test 123 Ave",
                //    State = "IL",
                //    PostalCode = "23422",
                //    City = "au"

                //}, "Admin@1992").GetAwaiter().GetResult();

                //ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "adminashan@gmail.com");

                //_userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();

            }
            return;
        }
    }
}
