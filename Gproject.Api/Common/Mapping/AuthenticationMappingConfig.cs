using Gproject.Application.Authentication.Commands.Register;
using Gproject.Application.Authentication.Common;
using Gproject.Application.Authentication.Queries.Login;
using Gproject.contracts.Authentication;
using Mapster;

namespace Gproject.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();

            config.NewConfig<LoginRequest, LoginQuery>();

            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Token, src => src.Token)
                .Map(dest => dest.FirstName, src => src.user.FullName.FirstName)   
                .Map(dest => dest.LastName, src => src.user.FullName.LastName)
                .Map(dest => dest.Email, src => src.user.Email)
                .Map(dest => dest.Id, src => src.user.Id);
        }
    }
}
