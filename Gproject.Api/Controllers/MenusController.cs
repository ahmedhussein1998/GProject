using Gproject.Application.Menus.Commands.CreateMenu;
using Gproject.contracts.Menus;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gproject.Api.Controllers
{
    
    public class MenusController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;
        public MenusController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [Route("hosts/{hostId}/menus")]
        [HttpPost]
        public async Task<IActionResult> CreateManu( CreateMenuRequest request)
        {
            
            var commend = _mapper.Map<CreateMenuCommand>(request);
            var CreateMenuResult = await _mediator.Send(commend);
            return CreateMenuResult.Match(
                menu => Ok(CreateMenuResult),
                errors => Problem(errors)
                );
        }
    }
}
