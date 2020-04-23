using Schlupy.Model.Common.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schlupy.Model.Models
{
    [Table("User")]
    public class User : BaseModel, IUser
    {
        #region Properties

        public string Email { get; set; }

        public string HashedPassword { get; set; }

        [NotMapped]
        public string Password { get; set; }

        public string PasswordSalt { get; set; }
        public string Username { get; set; }

        #endregion Properties
    }
}