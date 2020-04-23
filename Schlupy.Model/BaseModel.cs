using Schlupy.Model.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Schlupy.Model
{
    public class BaseModel : IBaseModel
    {
        #region Properties

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        [Key]
        public Guid Id { get; set; }

        #endregion Properties
    }
}