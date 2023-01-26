using Application.Abstractions.Messaging.Command;
using Application.Commands.User;
using Application.DTO;
using Application.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Route("users")]
public class UserController : ApiController
{
    private readonly ITokenStorage _tokenStorage;
    private readonly ICommandHandler<SignUpCommand> _signUpCommandHandler;
    private readonly ICommandHandler<SignInCommand> _signInCommandHandler;
    private readonly ICommandHandler<ChangeUserDetailsCommand> _changeUserDetailsCommandHandler;
    
    public UserController(ICommandHandler<SignUpCommand> signUpCommandHandler, 
        ICommandHandler<SignInCommand> signInCommandHandler, ITokenStorage tokenStorage, 
        ICommandHandler<ChangeUserDetailsCommand> changeUserDetailsCommandHandler)
    {
        _signUpCommandHandler = signUpCommandHandler;
        _signInCommandHandler = signInCommandHandler;
        _tokenStorage = tokenStorage;
        _changeUserDetailsCommandHandler = changeUserDetailsCommandHandler;
    }

    [HttpPost("signup")]
    public async Task<ActionResult> SignUp(SignUpCommand command)
    {
        await _signUpCommandHandler.HandleAsync(command);
        return NoContent();
    }

    [HttpPost("signin")]
    public async Task<ActionResult<JwtDto>> SignIn(SignInCommand command)
    {
        await _signInCommandHandler.HandleAsync(command);
        return Ok(_tokenStorage.Get());
    }

    [Authorize]
    [HttpPut("details")]
    public async Task<ActionResult> ChangeDetails(ChangeUserDetailsCommand command)
    {
        var userId = Guid.Parse(HttpContext.User.Identity?.Name);
        await _changeUserDetailsCommandHandler.HandleAsync(command with {UserId = userId});
        return NoContent();
    }
}