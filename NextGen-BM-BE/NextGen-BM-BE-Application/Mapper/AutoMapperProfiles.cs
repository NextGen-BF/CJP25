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
                )
                .ForMember(
                    dest => dest.UserBuildings,
                    opt => opt.MapFrom(src => src.UserBuildings)
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
                )
                .ForMember(
                    dest => dest.UserBuildings,
                    opt => opt.MapFrom(src => src.UserBuildings)
                );

            CreateMap<AddressViewModel, Address>();
            CreateMap<Address, AddressViewModel>();

            CreateMap<UserBuildingsViewModel, UserBuildings>()
                .ForMember(
                    dest => dest.UserBuildingsId,
                    opt => opt.MapFrom(src => src.UserBuildingsId)
                )
                .ForMember(dest => dest.BuildingId, opt => opt.MapFrom(src => src.BuildingId))
                .ForMember(dest => dest.Approved, opt => opt.MapFrom(src => src.Approved))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.Role, opt => opt.Ignore());

            CreateMap<UserBuildings, UserBuildingsViewModel>()
                .ForMember(
                    dest => dest.UserBuildingsId,
                    opt => opt.MapFrom(src => src.UserBuildingsId)
                )
                .ForMember(dest => dest.BuildingId, opt => opt.MapFrom(src => src.BuildingId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(
                    dest => dest.RoleId,
                    opt => opt.MapFrom(src => src.Role != null ? src.Role.Id : (int?)null)
                )
                .ForMember(dest => dest.Approved, opt => opt.MapFrom(src => src.Approved))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate));

            CreateMap<PropertyExpenseViewModel, PropertyExpense>();
            CreateMap<PropertyExpense, PropertyExpenseViewModel>();

            CreateMap<PropertyPaymentsViewModel, PropertyPayments>();
            CreateMap<PropertyPayments, PropertyPaymentsViewModel>();

            CreateMap<BuildingExpenseViewModel, BuildingExpense>();
            CreateMap<BuildingExpense, BuildingExpenseViewModel>();

            //Property models
            CreateMap<Property, PropertyViewModel>()
                .ForMember(dest => dest.PropertyType, opt => opt.MapFrom(src => src.PropertyType))
                .ForMember(dest => dest.PropertyPayments, opt => opt.MapFrom(src => src.Payments))
                .ForMember(
                    dest => dest.ResidentHistory,
                    opt => opt.MapFrom(src => src.PropertyResidents)
                );
            CreateMap<PropertyViewModel, Property>()
                .ForMember(dest => dest.Payments, opt => opt.MapFrom(src => src.PropertyPayments))
                .ForMember(dest => dest.PropertyType, opt => opt.Ignore())
                .ForMember(
                    dest => dest.PropertyTypeId,
                    opt => opt.MapFrom(src => src.PropertyType.TypeId)
                )
                .ForMember(
                    dest => dest.PropertyResidents,
                    opt => opt.MapFrom(src => src.ResidentHistory)
                );

            CreateMap<PropertyPayments, PropertyPaymentsViewModel>();
            CreateMap<PropertyPaymentsViewModel, PropertyPayments>();

            CreateMap<PropertyResidents, ResidentHistoryViewModel>();
            CreateMap<ResidentHistoryViewModel, PropertyResidents>();

            CreateMap<PropertyExpense, PropertyExpenseViewModel>();
            CreateMap<PropertyExpenseViewModel, PropertyExpense>();

            CreateMap<Enums, PropertyTypeViewModel>()
                .ForMember(dest => dest.TypeId, opt => opt.MapFrom(src => src.EnumsId));
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
