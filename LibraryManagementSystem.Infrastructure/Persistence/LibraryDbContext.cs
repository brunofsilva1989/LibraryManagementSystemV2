using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Infrastructure.Persistence
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        private string connectionString = "Server=DEVBRUNO;Database=LibraryDB;User Id=sa;Password=Bru@1989;TrustServerCertificate=True";

        //private string connectionString = "Server=WIN-RG8N89HJCU7;Database=LibraryDB; User Id=sa; Password=Bru@1989; TrustServerCertificate=True";
        public string ConnectionString { get => connectionString; set => connectionString = value; }
    }
}
