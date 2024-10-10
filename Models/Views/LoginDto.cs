﻿using System.ComponentModel.DataAnnotations;

namespace UserAPI.DTOs
{
    public class LoginDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
