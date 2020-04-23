using AutoMapper;
using Schlupy.Model.Models;

namespace Schlupy.WebAPI.Models
{
    public class RestMappings : Profile
    {
        #region Constructors

        public RestMappings()
        {
            CreateMap<User, RegistrationViewModel>().ReverseMap();
        }

        #endregion Constructors
    }
}