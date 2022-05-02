// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

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
public class SonarController : ControllerBase
{
    private readonly ILogger<SonarController> _logger;

    private readonly ISonarApplicationService _sonarApplicationService;

    private readonly IMapper _mapper;

    public SonarController(ILogger<SonarController> logger, ISonarApplicationService sonarApplicationService, IMapper mapper)
    {
        _logger = logger;
        _sonarApplicationService = sonarApplicationService;
        _mapper = mapper;
    }

    [HttpPost]
    [Route("/api/projects/sonar")]
    public async Task<IActionResult> Post(ProjectDto projectDto)
    {
        try
        {
            var project = _mapper.Map<Project>(projectDto);
            await _sonarApplicationService.Init(project);

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
