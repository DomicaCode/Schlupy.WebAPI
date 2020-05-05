using Schlupy.Model.Common.Models.Clock;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schlupy.Model.Models.Clock
{
    [Table("ClockEntry")]
    public class ClockEntry : BaseModel, IClockEntry
    {
        #region Properties

        public DateTime? DateEnded { get; set; }
        public DateTime DateStarted { get; set; }

        public bool IsRunning { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; } = null!;

        public Guid UserId { get; set; }

        #endregion Properties
    }
}