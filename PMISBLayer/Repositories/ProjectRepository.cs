﻿using Domain.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMISBLayer.Data;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace PMISBLayer.Repositories
{
     public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProjectRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public List<Project> GetAllProjects()
        {
            return _context.Projects.Include(p => p.ProjectType).ToList();
        }
        public void CreateProject(CreateProjectDto projectDto)
        {
            var userId= _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Project project = new Project()
            {
                Name = projectDto.Name,
                Description = projectDto.Description,
                ProjectTypeId = projectDto.ProjectTypeId,
                ProjectStatusId = projectDto.ProjectStatusId,
                StartDate = projectDto.StartDate,
                EndDate = projectDto.EndDate,
                ClientId=projectDto.ClientId,
                ContractAmount = projectDto.ContractAmount,
                ContractFileName = projectDto.ContractFile.FileName,
                ContractFileType = projectDto.ContractFile.ContentType,
                ContractFile = GetContractBytes(projectDto),
                ProjectManagerId = userId
        };
            _context.Projects.Add(project);
            Save();
        }

        public void DeleteProject(int projectId)
        {
            var ProjectToDelete=_context.Projects.Find(projectId);
            _context.Projects.Remove(ProjectToDelete);
            Save();
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public Byte[] GetContractBytes(CreateProjectDto projectDto)
        {
            Stream stream = projectDto.ContractFile.OpenReadStream();
            BinaryReader binaryReader = new BinaryReader(stream);
            var byteFile = binaryReader.ReadBytes((int)stream.Length);
            return byteFile;
        }

        public FileStreamResult ViewContract(int projectId)
        {
            Project project = GetProject(projectId);
            Stream stream = new MemoryStream(project.ContractFile);
            return new FileStreamResult(stream,project.ContractFileType);
        }

        public List<Project> GetManagerProjects(string userId)
        {
            return _context.Projects
                .Include(p=> p.ProjectType)
                .Where(p => p.ProjectManagerId == userId)
                .ToList();
        }

        public Project GetProject(int projectId)
        {
            var project= _context.Projects
                .Include(p => p.ProjectPhase)
                .ThenInclude(pp => pp.Phase)
                .SingleOrDefault(p => p.Id == projectId);
            return project;
        }

        public void UpdateProject(UpdateProjectDto projectDto)
        {
            Stream stream = projectDto.ContractFile.OpenReadStream();
            BinaryReader binaryReader = new BinaryReader(stream);
            var byteFile = binaryReader.ReadBytes((int)stream.Length);
            var project = _context.Projects.Find(projectDto.Id);
            project.Name = projectDto.Name;
            project.ContractAmount = projectDto.ContractAmount;
            project.StartDate = projectDto.StartDate;
            project.EndDate = projectDto.EndDate;
            project.ContractFileName = projectDto.ContractFile.FileName;
            project.ContractFileType = projectDto.ContractFile.ContentType;
            project.ContractFile = byteFile;
            Save();
        }
    }
}