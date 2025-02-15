using System.Runtime.Serialization;

namespace LibraryManagementSystem.Domain.Enum
{
    public class LoanEnums
    {
        /// <summary>
        /// Enum to represent the status of a loan
        /// </summary>
        public enum LoanStatus
        {
            [EnumMember(Value = "Pendente")]
            Pending = 0,
            [EnumMember(Value = "Aprovado")]
            Approved = 1,
            [EnumMember(Value = "Devolvido")]
            Returned = 2,
            [EnumMember(Value = "Atrasado")]
            Late = 3
        }
    }
}
