using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Domain.Enum
{
    public class LoanEnums
    {
        /// <summary>
        /// Enum to represent the status of a loan
        /// </summary>
        public enum LoanStatus
        {
            Pending = 0,
            Approved = 1,
            Returned = 2,
            Late = 3
        }
    }
}
