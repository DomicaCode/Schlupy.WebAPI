using System;

namespace Schlupy.Model.Common.Models.Clock
{
    public interface IClockEntry
    {
        #region Properties

        DateTime? DateEnded { get; set; }
        DateTime DateStarted { get; set; }

        bool IsRunning { get; set; }

        Guid UserId { get; set; }

        #endregion Properties
    }
}