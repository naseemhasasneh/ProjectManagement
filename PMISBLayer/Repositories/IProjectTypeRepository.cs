using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Repositories
{
    public interface IProjectTypeRepository
    {
        List<ProjectType> GetProjectTypes();
    }
}
