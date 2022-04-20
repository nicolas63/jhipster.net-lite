using AutoMapper;
using JHipster.NetLite.Application.Services.Interfaces;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Web.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHipster.NetLite.Web.Controllers.Projects;

[ApiController]
[Route("[controller]")]
public class APIController : ControllerBase
{
    private readonly ILogger<APIController> _logger;

    private readonly IInitApplicationAPI _initApplicationAPI;

    private readonly IMapper _mapper;

    public APIController(ILogger<APIController> logger, IInitApplicationAPI initApplicationAPI, IMapper mapper)
    {
        _logger = logger;
        _initApplicationAPI = initApplicationAPI;
        _mapper = mapper;
    }

    [HttpPost]
    [Route("/api/projects/api")]
    public async Task<IActionResult> Post(ProjectDto projectDto)
    {
        try
        {
            var project = _mapper.Map<Project>(projectDto);
            await _initApplicationAPI.Init(project);

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
