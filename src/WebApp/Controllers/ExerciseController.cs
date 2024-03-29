using Application.Abstractions.Messaging.Command;
using Application.Abstractions.Messaging.Query;
using Application.Commands.Exercise;
using Application.DTO.Entities;
using Application.Queries.Exercise;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Authorize]
[Route("api/exercises")]
public class ExerciseController : ApiController
{
    private readonly ICommandHandler<CreateExerciseCommand> _createExerciseCommandHandler;
    private readonly ICommandHandler<EditExerciseCommand> _editExerciseCommandHandler;
    private readonly ICommandHandler<RemoveExerciseCommand> _removeExerciseCommandHandler;
    private readonly IQueryHandler<GetExercisesQuery,IEnumerable<ExerciseDto>> _getExercisesQueryHandler;
    private readonly IQueryHandler<GetExerciseQuery,ExerciseDto> _getExerciseQueryHandler;
    private Guid _userId;

    public ExerciseController(ICommandHandler<CreateExerciseCommand> createExerciseCommandHandler, 
        IQueryHandler<GetExercisesQuery, IEnumerable<ExerciseDto>> getExercisesQueryHandler, 
        IQueryHandler<GetExerciseQuery, ExerciseDto> getExerciseQueryHandler, 
        ICommandHandler<EditExerciseCommand> editExerciseCommandHandler, 
        ICommandHandler<RemoveExerciseCommand> removeExerciseCommandHandler)
    {
        _createExerciseCommandHandler = createExerciseCommandHandler;
        _getExercisesQueryHandler = getExercisesQueryHandler;
        _getExerciseQueryHandler = getExerciseQueryHandler;
        _editExerciseCommandHandler = editExerciseCommandHandler;
        _removeExerciseCommandHandler = removeExerciseCommandHandler;
    }
    
    [HttpPost("create")]
    public async Task<ActionResult> Post(CreateExerciseCommand command)
    {
        _userId = Guid.Parse(HttpContext.User.Identity.Name);
        await _createExerciseCommandHandler.HandleAsync(command with {UserId = _userId});
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Post(Guid id,EditExerciseCommand editExerciseCommand)
    {
        _userId = Guid.Parse(HttpContext.User.Identity.Name);
        await _editExerciseCommandHandler.HandleAsync(editExerciseCommand with { UserId = _userId, ExerciseId = id});
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        _userId = Guid.Parse(HttpContext.User.Identity.Name);
        await _removeExerciseCommandHandler.HandleAsync(new RemoveExerciseCommand(_userId,id));
        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        _userId = Guid.Parse(HttpContext.User.Identity.Name);
        var result = await _getExercisesQueryHandler.HandleAsync(new GetExercisesQuery(_userId));
        return Ok(result);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetSpecific(Guid id)
    {
        _userId = Guid.Parse(HttpContext.User.Identity.Name);
        var result = await _getExerciseQueryHandler.HandleAsync(new GetExerciseQuery(_userId,id));
        return Ok(result);
    }
    
}