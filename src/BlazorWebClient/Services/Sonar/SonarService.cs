using AutoMapper;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Web.DTO;

namespace BlazorWebClient.Services.Sonar;

public class SonarService : ISonarService
{
    protected readonly HttpClient _httpClient;
    protected readonly IMapper _mapper;

    public SonarService(HttpClient httpClient, IMapper mapper)
    {
        _httpClient = httpClient;
        _mapper = mapper;
    }

    public virtual async Task Post(Project project)
    {
        var projectDto = _mapper.Map<ProjectDto>(project);
        await _httpClient.PostAsJsonAsync("https://localhost:7107/api/projects/sonar", projectDto);
    }
}
