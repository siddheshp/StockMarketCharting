using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StckMarket.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Username { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        public UserType UserType { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public long Mobile { get; set; }
        public bool Confirmed { get; set; }
    }
}
