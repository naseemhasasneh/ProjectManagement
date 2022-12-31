using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Repositories
{
    public interface IPhaseRepository
    {
        List<Phase> GetAllPhases();
        //public string GetAllPhasesBYProject(int projectId);
        //List<Phase> GetProjectPhases(int projectId);
    }
}
