using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.DTOs
{
    public class UsersDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required(ErrorMessage = "CPF is required")]
        [StringLength(11, ErrorMessage = "CPF cannot exceed 11 characters")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(8, ErrorMessage = "Password cannot exceed 8 characters")]
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
