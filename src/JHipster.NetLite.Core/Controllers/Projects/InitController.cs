using AutoMapper;
using JHipster.NetLite.Application.Services.Interfaces;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Web.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JHipster.NetLite.Web.Controllers.Projects;

[ApiController]
[Route("[controller]")]
public class InitController : ControllerBase
{
    private readonly ILogger<InitController> _logger;

    private readonly IInitApplicationService _initApplicationService; 

    private readonly IMapper _mapper;

    public InitController(ILogger<InitController> logger, IInitApplicationService initApplicationService, IMapper mapper)
    {
        _logger = logger;
        _initApplicationService = initApplicationService;
        _mapper = mapper;
    }

    [HttpPost]
    [Route("/api/projects/init")]
    public async Task<IActionResult> Post(ProjectDto projectDto)
    {
        try
        {
            var project = _mapper.Map<Project>(projectDto);
            await _initApplicationService.Init(project);

            _logger.LogInformation("Request succes");
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception in the Post method");
            return BadRequest(ex.Message);
        }
    }


}
