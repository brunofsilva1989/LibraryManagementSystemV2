using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.DTOs
{
    public class BookDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Author is required")]
        [StringLength(100, ErrorMessage = "Author cannot exceed 100 characters")]
        public string Author { get; set; }
        [Required(ErrorMessage = "ISBN is required")]
        [StringLength(13, ErrorMessage = "ISBN cannot exceed 13 characters")]
        public string ISBN { get; set; }
        [Range(1500, 2025,ErrorMessage = "Year must be between 1500 and 2025")]
        public int YearPublication { get; set; }        
    }
}
