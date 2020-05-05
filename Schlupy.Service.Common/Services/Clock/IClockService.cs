using Schlupy.Model.Models.Clock;
using System;
using System.Threading.Tasks;

namespace Schlupy.Service.Common.Services.Clock
{
    public interface IClockService
    {
        #region Methods

        Task<bool> InsertAsync(ClockEntry model, Guid userId);

        #endregion Methods
    }
}