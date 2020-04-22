using Microsoft.EntityFrameworkCore;
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
    }
}