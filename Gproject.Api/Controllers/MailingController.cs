using Gproject.Application.Emails.Commands.SendEmail;
using Gproject.Application.Menus.Commands.CreateMenu;
using Gproject.Application.Menus.Queries.GetAllMenus;
using Gproject.Application.Menus.Queries.GetMenuById;
using Gproject.contracts.Menus;
using Gproject.Infrastruct.Services;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gproject.Api.Controllers
{
    
    public class MailingController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;
        public MailingController(IMediator mediator, IMapper mapper, IHttpContextAccessor httpContextAccessor) :base(httpContextAccessor)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [Route("SendMail")]
        [HttpPost]
        [AllowAnonymous]
        //[Authorize(Permissions.Emails.Create)]
        public async Task<IActionResult> SendMail(SendEmailRequest request)
        {
            
            var commend = _mapper.Map<SendEmailCommand>(request);
            var SendEmailResult = await _mediator.Send(commend);
            return SendEmailResult.Match(
                menu => Ok(SendEmailResult),
                errors => Problem(errors)
                );
        }

        //[Route("menus")]
        //[HttpGet]
        //[Authorize(Permissions.Menus.View)]
        //public async Task<IActionResult> GetAllMenus([FromQuery] GetAllMenusQuery query)
        //{
        //    var menus = await _mediator.Send(query);

        //    return menus.Match(
        //        menus => Ok(menus),
        //        errors => Problem(errors)
        //        );

        //}


        //[Route("menu")]
        //[HttpGet]
        //[Authorize(Permissions.Menus.View)]
        //public async Task<IActionResult> GetMenuById([FromQuery] Guid id)
        //{
        //    var query = new GetMenuByIdQuery(id);
        //    var menu = await _mediator.Send(query);

        //    return menu.Match(
        //        menu => Ok(menu),
        //        errors => Problem(errors)
        //        );

        //}



    }
}
