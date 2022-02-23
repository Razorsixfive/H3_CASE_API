using AutoMapper;
using H3_CASE_API.Models;
using H3_CASE_API.Dto;

namespace H3_CASE_API.Profiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {

            // Customer
            CreateMap<Customer, CustomerDto>().IncludeMembers(x => x.Contact_Informaition)
                .ForMember(dest => dest.Full_Name, opt => opt.MapFrom
                    (src => $"{src.Contact_Informaition.First_Name} {src.Contact_Informaition.Last_Name}"))
                .ForMember(dest => dest.ContactType, opt => opt.MapFrom
                    (src => src.Contact_Informaition.Contact_Type.ContactType))
                .ForMember(dest => dest.addreses, opt => opt.MapFrom
                    (src => src.Contact_Informaition.Addrese));
            CreateMap<Addrese, AddreseDto>(MemberList.None).IncludeMembers(x => x.PostalCodes)
                .ForMember(dest => dest.City, opt => opt.MapFrom
                    (src => src.PostalCodes.City));
            CreateMap<Contact_Informaition, CustomerDto>(MemberList.None);
            CreateMap<Addrese, CustomerDto>(MemberList.None);
            CreateMap<PostalCodes, AddreseDto>(MemberList.None);
            CreateMap<Contact_Type, CustomerDto>(MemberList.None);

            // Warehouse
            CreateMap<Warehouse, WarehousesDto>().IncludeMembers(x => x.Contact_Informaition)
                .ForMember(dest => dest.WarehouseName, otp => otp.MapFrom(src => $"{src.Contact_Informaition.First_Name} {src.Contact_Informaition.Last_Name}"))
                .ForMember(dest => dest.addreses, opt => opt.MapFrom(src => src.Contact_Informaition.Addrese))
                .ForMember(dest => dest.DepartmentID, opt => opt.MapFrom(src => src.DepartmentID));

            CreateMap<Department, WarehousesDto>(MemberList.None);
            CreateMap<Contact_Informaition, WarehousesDto>(MemberList.None);
            CreateMap<Contact_Type, WarehousesDto>(MemberList.None);

            CreateMap<Product_Stock, Product_StockDto>(MemberList.None)
               .ForMember(dest => dest.Product_Name, opt => opt.MapFrom(src => src.Product.Product_Name));


            // Products
            CreateMap<Product, ProductDto>();
            CreateMap<Category, ProductDto>(MemberList.None);
            CreateMap<Manufactor, ProductDto>(MemberList.None);
        }
    }
}
