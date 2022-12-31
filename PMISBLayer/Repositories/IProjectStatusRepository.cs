using PMISBLayer.Data;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Repositories
{
    public interface IProjectStatusRepository
    {
        List<ProjectStatus> GetProjectStatus();
    }
}
