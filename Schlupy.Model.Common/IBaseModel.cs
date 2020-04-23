using System;

namespace Schlupy.Model.Common
{
    public interface IBaseModel
    {
        #region Properties

        DateTime DateCreated { get; set; }
        DateTime DateUpdated { get; set; }
        Guid Id { get; set; }

        #endregion Properties
    }
}