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
public class GithubActionController : ControllerBase
{
    private readonly ILogger<GithubActionController> _logger;

    private readonly IInitApplicationGithubAction _initApplicationGithubAction;

    private readonly IMapper _mapper;

    public GithubActionController(ILogger<GithubActionController> logger, IInitApplicationGithubAction initApplicationGithubAction, IMapper mapper)
    {
        _logger = logger;
        _initApplicationGithubAction = initApplicationGithubAction;
        _mapper = mapper;
    }

    [HttpPost]
    [Route("/api/projects/CI/GithubAction")]
    public async Task<IActionResult> Post(ProjectDto projectDto)
    {
        try
        {
            var project = _mapper.Map<Project>(projectDto);
            await _initApplicationGithubAction.Init(project);

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
