using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LibraryManagementSystem.Domain.Enum.LoanEnums;

namespace LibraryManagementSystem.Domain.Model
{
    public class LoanModel
    {        
        public LoanModel()
        {
            
        }

        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public DateTime Loans { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public LoanStatus Status { get; set; }

    }
}
