﻿using System.ComponentModel.DataAnnotations;

namespace front.Dtos.Auth
{
    public class LoginDto
    {
        [Required(ErrorMessage = "El nombre de usuario es requerido.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida.")]
        public string Password { get; set; }
    }
}
