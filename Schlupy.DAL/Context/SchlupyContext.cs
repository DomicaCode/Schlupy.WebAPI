using Microsoft.EntityFrameworkCore;
using Schlupy.Model.Models;
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

        public DbSet<User> FoodItem { get; set; }

        #endregion Properties
    }
}