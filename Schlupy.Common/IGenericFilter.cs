using System;

namespace Schlupy.Common
{
    public interface IGenericFilter
    {
        #region Properties

        string Abrv { get; set; }
        Guid? Id { get; set; }
        string Name { get; set; }

        #endregion Properties
    }
}