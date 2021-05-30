using AutoMapper;
using Cotecna.API.Inspections.ViewModels;
using Cotecna.Inspections.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cotecna.API.Inspections
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<InspectorInfo, InspectorInfoViewModel>()
                .ReverseMap();

            CreateMap<Inspection, InspectionViewModel>()
                .ReverseMap();

            CreateMap<InspectionCreationViewModel, Inspection>();
        }
    }
}
