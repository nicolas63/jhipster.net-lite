using AutoMapper;
using BlazorWebClient.Services.Interfaces;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Web.DTO;

namespace BlazorWebClient.Services;

public class BlazorService : IBlazorService
{
    protected readonly HttpClient _httpClient;
    protected readonly IMapper _mapper;

    public BlazorService(HttpClient httpClient, IMapper mapper)
    {
        _httpClient = httpClient;
        _mapper = mapper;
    }

    public virtual async Task Post(Project project)
    {
        var projectDto = _mapper.Map<ProjectDto>(project);
        await _httpClient.PostAsJsonAsync("https://localhost:7107/api/projects/clients/Blazor", projectDto);
    }
}
