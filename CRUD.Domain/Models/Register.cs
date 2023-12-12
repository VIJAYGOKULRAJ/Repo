﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace CRUD.Domain.Models
{
    public class Register 
    {
        [Key]
        public Guid UserID { get; set; }
        [Required]
        public string  Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }

  
}
