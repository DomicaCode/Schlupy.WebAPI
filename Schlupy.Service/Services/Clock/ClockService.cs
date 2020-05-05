using Schlupy.Model.Models.Clock;
using Schlupy.Repository.Common.Repositories;
using Schlupy.Service.Common.Services.Clock;
using System;
using System.Threading.Tasks;

namespace Schlupy.Service.Services.Clock
{
    public class ClockService : IClockService
    {
        #region Constructors

        public ClockService(IClockRepository clockRepository)
        {
            ClockRepository = clockRepository;
        }

        #endregion Constructors

        #region Properties

        public IClockRepository ClockRepository { get; }

        #endregion Properties

        #region Methods

        public async Task<bool> InsertAsync(ClockEntry model, Guid userId)
        {
            model.IsRunning = true;
            model.DateStarted = DateTime.Now;
            model.UserId = userId;

            return await ClockRepository.InsertAsync(model).ConfigureAwait(false);
        }

        #endregion Methods
    }
}