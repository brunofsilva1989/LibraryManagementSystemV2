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
        public LoanModel() {  }

        public LoanModel(int id, int idUser, int idBook, DateTime loanDate, DateTime returnDate, DateTime actualReturnDate, LoanStatus status, int renewCount)
        {
            Id = id;
            IdUser = idUser;
            IdBook = idBook;
            LoanDate = loanDate;
            ReturnDate = returnDate;
            ActualReturnDate = actualReturnDate;
            Status = status;
            RenewCount = renewCount;
        }

        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime ActualReturnDate { get; set; }
        public LoanStatus Status { get; set; }
        public int RenewCount { get; set; }

    }
}
