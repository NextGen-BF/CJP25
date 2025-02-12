using System.Runtime.InteropServices;
using AutoMapper;
using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Entities.BuildingAggregate;
using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Domain.Entities.RequestAggregate;
using NextGen_BM_BE_Domain.ViewModels;

namespace NextGen_BM_BE_Application.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<BuildingViewModel, Building>()
                .ForMember(
                    dest => dest.AddressId,
                    src => src.MapFrom(x => x.BuildingAddress.AddressId)
                )
                .ForMember(
                    dest => dest.BuildingAddress,
                    opt => opt.MapFrom(src => src.BuildingAddress)
                )
                .ForMember(
                    dest => dest.BuildingExpenses,
                    opt => opt.MapFrom(src => src.BuildingExpenses)
                )
                .ForMember(
                    dest => dest.Properties,
                    opt => opt.MapFrom(src => src.BuildingProperties)
                );

            CreateMap<Building, BuildingViewModel>()
                .ForMember(
                    dest => dest.BuildingAddress,
                    opt => opt.MapFrom(src => src.BuildingAddress)
                )
                .ForMember(
                    dest => dest.BuildingExpenses,
                    opt => opt.MapFrom(src => src.BuildingExpenses)
                )
                .ForMember(
                    dest => dest.BuildingProperties,
                    opt => opt.MapFrom(src => src.Properties)
                );

            CreateMap<Address, AddressViewModel>();
            CreateMap<AddressViewModel, Address>();

            CreateMap<BuildingExpense, BuildingExpenseViewModel>();
            CreateMap<BuildingExpenseViewModel, BuildingExpense>();

            CreateMap<PropertyExpense, PropertyExpenseViewModel>();
            CreateMap<PropertyExpenseViewModel, PropertyExpense>();
            //Request models
            CreateMap<RepairRequest, RepairRequestViewModel>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.RequestStatus))
                .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes))
                .ForMember(dest => dest.RequestId, opt => opt.MapFrom(src => src.RepairRequestId));
            CreateMap<RepairRequestViewModel, RepairRequest>()
                .ForMember(
                    dest => dest.RequestStatusId,
                    opt => opt.MapFrom(src => src.Status.StatusId)
                )
                .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes))
                .ForMember(dest => dest.RepairRequestId, opt => opt.MapFrom(src => src.RequestId));

            CreateMap<RequestNotes, RequestNotesViewModel>()
                .ForMember(dest => dest.NoteId, opt => opt.MapFrom(src => src.RequestNotesId));
            CreateMap<RequestNotesViewModel, RequestNotes>()
                .ForMember(dest => dest.RequestNotesId, opt => opt.MapFrom(src => src.NoteId));

            CreateMap<Enums, RequestStatusViewModel>()
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.EnumsId));
            CreateMap<RequestStatusViewModel, Enums>()
                .ForMember(dest => dest.EnumsId, opt => opt.MapFrom(src => src.StatusId));
        }
    }
}
