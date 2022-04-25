using JHipster.NetLite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHipster.NetLite.Domain.Services.Interfaces;

public interface IInitDomainApi
{
    Task Init(Project project);
}
