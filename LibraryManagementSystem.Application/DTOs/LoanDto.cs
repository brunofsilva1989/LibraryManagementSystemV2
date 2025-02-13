using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.DTOs
{
    public class LoanDto
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public DateTime Loans { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int Status { get; set; }
    }
}
