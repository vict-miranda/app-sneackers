﻿using System.ComponentModel.DataAnnotations;

namespace AppSneackers.API.Mapping
{
    public class AuthorizationDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
