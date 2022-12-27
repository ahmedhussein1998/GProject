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
                .Map(dest => dest, src => src.user);
        }
    }
}
