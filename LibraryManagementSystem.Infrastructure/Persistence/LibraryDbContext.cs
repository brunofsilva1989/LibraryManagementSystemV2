using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Infrastructure.Persistence
{
    public class LibraryDbContext
    {
        private string connectionString = "Server=DEVBRUNO;Database=LibraryDB;User Id=sa;Password=Bru@1989;TrustServerCertificate=True";

        public string ConnectionString { get => connectionString; set => connectionString = value; }
    }
}
