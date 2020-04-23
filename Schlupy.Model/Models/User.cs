using Schlupy.Model.Common.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schlupy.Model.Models
{
    [Table("User")]
    public class User : IUser
    {
        #region Properties

        public string Email { get; set; }

        [Key]
        public Guid Id { get; set; }

        public string Password { get; set; }
        public string Username { get; set; }

        #endregion Properties
    }
}