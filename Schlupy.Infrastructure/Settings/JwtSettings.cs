namespace Schlupy.Infrastructure.Settings
{
    public class JwtSettings : IJwtSettings
    {
        #region Properties

        public string Secret { get; set; }

        #endregion Properties
    }
}