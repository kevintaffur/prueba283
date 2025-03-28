using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public partial class Usuario
    {
        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string Username { get; set; } = null!;
        [StringLength(255)]
        [Unicode(false)]
        public string PasswordHash { get; set; } = null!;
        public int RolId { get; set; }

        [ForeignKey("RolId")]
        [InverseProperty("Usuarios")]
        public virtual Role Rol { get; set; } = null!;
    }
}
