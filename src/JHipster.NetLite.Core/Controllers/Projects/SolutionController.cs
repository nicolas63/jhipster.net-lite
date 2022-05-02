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
public class SolutionController : ControllerBase
{
    private readonly ILogger<SolutionController> _logger;

    private readonly ISolutionApplicationService _solutionApplicationService;

    private readonly IMapper _mapper;

    public SolutionController(ILogger<SolutionController> logger, ISolutionApplicationService solutionApplicationService, IMapper mapper)
    {
        _logger = logger;
        _solutionApplicationService = solutionApplicationService;
        _mapper = mapper;
    }

    [HttpPost]
    [Route("/api/projects/solution")]
    public async Task<IActionResult> Post(ProjectDto projectDto)
    {
        try
        {
            var project = _mapper.Map<Project>(projectDto);
            await _solutionApplicationService.Init(project);

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
