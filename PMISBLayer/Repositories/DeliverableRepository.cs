using AutoMapper;
using Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using PMISBLayer.Data;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBLayer.Repositories
{
    public class DeliverableRepository : IDeliverableRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeliverableRepository(ApplicationDbContext dbContext,IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public void CreateDeliverable(CreateDeliverableDto deliverableDto)
        {
            //var deliverable = new Deliverable()
            //{
            //    Name = deliverableDto.Name,
            //    Description = deliverableDto.Description,
            //    StartDate = deliverableDto.StartDate,
            //    EndDate = deliverableDto.EndDate,
            //    ProjectPhaseId = deliverableDto.ProjectPhaseId
            //};
            var deliverable = _mapper.Map<Deliverable>(deliverableDto);
            _context.Deliverables.Add(deliverable);
            _context.SaveChanges();
        }

        public void DeleteDeliverable(int deliverableId)
        {
            var DeliverableToDelete = _context.Deliverables.Find(deliverableId);
            _context.Deliverables.Remove(DeliverableToDelete);
            _context.SaveChanges();
        }

        public Deliverable GetDeliverable(int deliverableId)
        {
            return _context.Deliverables
                .Include(d => d.ProjectPhase)
                .ThenInclude(pp=>pp.Project)
                .SingleOrDefault(d => d.Id == deliverableId);
        }

        public List<Deliverable> GetDeliverables(string userId)
        {
            return _context.Deliverables
                .Include(d => d.ProjectPhase)
                .ThenInclude(pp => pp.Project)
                .Where(d => d.ProjectPhase.Project.ProjectManagerId == userId)
                .ToList();
        }

        public List<Deliverable> GetDeliverablesByProject(int projectId)
        {
            return _context.Deliverables
                .Include(d=>d.ProjectPhase.Phase)
                .Where(d=>d.ProjectPhase.ProjectId==projectId)
                .ToList();
        }

        public void UpdateDeliverable(UpdateDeliverableDto deliverableDto)
        {
            var deliverableToUpdate = _context.Deliverables.Find(deliverableDto.Id);
            deliverableToUpdate.Name = deliverableDto.Name;
            deliverableToUpdate.Description = deliverableDto.Description;
            deliverableToUpdate.StartDate = deliverableDto.StartDate;
            deliverableToUpdate.EndDate = deliverableDto.EndDate;
            _context.SaveChanges();
        }
    }
}
