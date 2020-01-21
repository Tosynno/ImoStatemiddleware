using ImoStatemiddleware.Data.AuthenticationModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImoStatemiddleware.Utility.DBContext
{
    public class AuthenticationUtilityDBContext : DbContext
    {
        public static string ConnectionString { get; set; }
        public DbSet<AuthenticationRequest> AuthenticationRequests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
