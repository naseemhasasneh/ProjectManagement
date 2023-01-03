using AutoMapper;
using Domain.Dtos;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Profiles
{
    public class DeliverableProfile :Profile
    {
        public DeliverableProfile()
        {
            CreateMap<CreateDeliverableDto,Deliverable>().ReverseMap();
        }
    }
    
}
