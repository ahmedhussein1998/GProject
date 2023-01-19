using Gproject.Application.Menus.Commands.CreateMenu;
using Gproject.contracts.Menus;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gproject.Api.Controllers
{
    [Route("hosts/{hostId}/menus")]
    public class MenusController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;
        public MenusController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateManu([FromRoute] string hostId, CreateMenuRequest request)
        {
            var commend = _mapper.Map<CreateMenuCommand>((request, hostId));
            var CreateMenuResult = await _mediator.Send(commend);
            return CreateMenuResult.Match(
                menu => Ok(_mapper.Map<MenuResponse>(menu)),
                errors => Problem(errors)
                );
        }
    }
}
