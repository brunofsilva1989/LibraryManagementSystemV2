using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Domain.Model
{
    public class UserModel
    {
        public UserModel(int id, string cpf, string name, string email)
        {
            Id = GenerateId();
            CPF = cpf;
            Name = name;
            Email = email;
        }

        public UserModel()
        {
            
        }

        public int Id { get; private set; }
        public string CPF { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public int GenerateId()
        {
            return new Random().Next(1, 1000);
        }
    }
}
