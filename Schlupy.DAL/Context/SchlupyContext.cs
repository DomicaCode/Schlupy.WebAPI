using Microsoft.EntityFrameworkCore;
using Schlupy.Model.Models;
using Schlupy.Model.Models.Clock;
using System.Diagnostics.CodeAnalysis;

namespace Schlupy.DAL.Context
{
    public class SchlupyContext : DbContext
    {
        #region Constructors

        public SchlupyContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        #endregion Constructors

        #region Properties

        public DbSet<ClockEntry> ClockEntry { get; set; }
        public DbSet<User> User { get; set; }

        #endregion Properties
    }
}