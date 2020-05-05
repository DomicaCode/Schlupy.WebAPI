using Schlupy.Common;
using Schlupy.Model.Models.Clock;
using Schlupy.Repository.Common.Repositories;

namespace Schlupy.Repository.Repositories
{
    public class ClockRepository : BaseRepository<ClockEntry, GenericFilter>, IClockRepository
    {
        #region Constructors

        public ClockRepository(DAL.Context.SchlupyContext context, AutoMapper.IMapper mapper) : base(context, mapper)
        {
        }

        #endregion Constructors
    }
}