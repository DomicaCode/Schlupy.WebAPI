using System;

namespace Schlupy.Common
{
    public class GenericFilter : IGenericFilter
    {
        #region Properties

        public string Abrv { get; set; } = null!;

        public Guid? Id { get; set; }

        public string Name { get; set; } = null!;

        #endregion Properties
    }
}