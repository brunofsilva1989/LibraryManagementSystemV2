using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Domain.Model
{
    public class UserModel
    {
        public UserModel() { }

        public UserModel(int id, string cpf, string name, string email, string password)
        {
            Id = id;
            CPF = cpf;
            Name = name;
            Email = email;
            Password = password;
            CreationDate = DateTime.Now;
        }        

        public int Id { get; set; }
        public string CPF { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}
