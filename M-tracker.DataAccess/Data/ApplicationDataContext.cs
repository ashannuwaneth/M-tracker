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
    }
}
