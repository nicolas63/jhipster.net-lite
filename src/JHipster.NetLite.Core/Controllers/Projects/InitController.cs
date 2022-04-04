using JHipster.NetLite.Web.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JHipster.NetLite.Web.Controllers.Projects;

[ApiController]
[Route("[controller]")]
public class InitController : ControllerBase
{
    private readonly ILogger<InitController> _logger;

    public InitController(ILogger<InitController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    [Route("/api/projects/init")]
    public void Post(ProjectDto project)
    {
    }
}
