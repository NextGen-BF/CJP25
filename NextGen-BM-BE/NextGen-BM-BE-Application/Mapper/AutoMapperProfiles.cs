using System.Runtime.InteropServices;
using AutoMapper;
using NextGen_BM_BE_Domain.Entities.BuildingAggregate;
using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
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

            CreateMap<PropertyPayments, PropertyPaymentsViewModel>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.Title))
                .ForMember(
                    dest => dest.PaymentMethod,
                    opt => opt.MapFrom(src => src.PaymentMethod.Title)
                );
        }
    }
}
