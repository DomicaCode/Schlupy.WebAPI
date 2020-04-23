using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Schlupy.Model.Common;

namespace Schlupy.Model
{
    public class ModelMappings : Profile
    {
        #region Constructors

        public ModelMappings()
        {
            CreateMap<SecurityToken, Token>().ReverseMap();
            CreateMap<SecurityToken, IToken>().ReverseMap();

            CreateMap<Token, IToken>().ReverseMap();
        }

        #endregion Constructors
    }
}