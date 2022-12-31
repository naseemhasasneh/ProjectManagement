using Domain.Dtos;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Repositories
{
    public interface IDeliverableRepository
    {
        List<Deliverable> GetDeliverables(string userId);
        List<Deliverable> GetDeliverablesByProject(int projectId);
        Deliverable GetDeliverable(int deliverableId);
        void CreateDeliverable(CreateDeliverableDto deliverableDto);
        void UpdateDeliverable(UpdateDeliverableDto deliverableDto);
        void DeleteDeliverable(int deliverableId);
    }
}
