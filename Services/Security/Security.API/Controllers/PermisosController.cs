using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Security.Application.CQRS.Commands;
using Security.Application.CQRS.Queries;
using Security.Application.DTO.Response;
using Security.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Security.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PermissionsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<Permissions>> Get()
        {
            return await _mediator.Send(new GetPermissionsQuery());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Permissions> Get(Int64 id)
        {
            return await _mediator.Send(new GetPermissionQuery(id));
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> ModifyPermission(int id, [FromBody] ModifyPermissionCommand command)
        {
            try
            {
                if (command.Id == id)
                {
                    var result = await _mediator.Send(command);
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

        /*[HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Permissions> Get(Int64 id)
        {
            return await _mediator.Send(new GetPermissionsByIdQuery(id));
        }

        [HttpGet("email")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Permissions> GetByEmail(string email)
        {
            return await _mediator.Send(new GetPermissionsByEmailQuery(email));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PermissionsResponse>> CreatePermissions([FromBody] CreatePermissionsCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpPut("EditPermissions/{id}")]
        public async Task<ActionResult> EditPermissions(int id, [FromBody] EditPermissionsCommand command)
        {
            try
            {
                if (command.Id == id)
                {
                    var result = await _mediator.Send(command);
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }


        }

        [HttpDelete("DeletePermissions/{id}")]
        public async Task<ActionResult> DeletePermissions(int id)
        {
            try
            {
                string result = string.Empty;
                result = await _mediator.Send(new DeletePermissionsCommand(id));
                return Ok(result);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }*/

    }
}
