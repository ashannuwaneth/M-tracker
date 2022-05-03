using M_tracker.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_tracker.DataAccess.Data
{
    public class ApplicationDataContext : IdentityDbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
        {
        }

        public DbSet<ExpensesType> ExpensesTypes { get; set; }

        public DbSet<GroupType> GroupTypes { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }
        public DbSet<GroupTypeUser> GroupTypeUsers { get; set; }
        public DbSet<GroupExpensesManage> GroupExpensesManages { get; set; }
        public DbSet<GroupTotal> GroupTotals { get; set; }
        public IEnumerable<object> IdentityUser { get; internal set; }
    }
}
