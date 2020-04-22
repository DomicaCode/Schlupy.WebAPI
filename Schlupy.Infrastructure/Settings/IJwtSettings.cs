namespace Schlupy.Infrastructure.Settings
{
    public interface IJwtSettings
    {
        string Secret { get; set; }
    }
}