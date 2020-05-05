namespace Schlupy.Model.Common.Models
{
    public interface IUser : IBaseModel
    {
        #region Properties

        string Email { get; set; }

        string HashedPassword { get; set; }

        string PasswordSalt { get; set; }
        string Username { get; set; }

        #endregion Properties
    }
}