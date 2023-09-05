﻿using AutoMapper;
using Entities.Universal.MainData;
using Universal.DTO.IDTO;
using Universal.DTO.ODTO;

namespace Entities.Mapping
{
    public class UniversalMappingProfile : Profile
    {
        public UniversalMappingProfile()
        {
            CreateMap<Product, ProductODTO>();
            CreateMap<ProductIDTO, Product>();
            CreateMap<ProductODTO, ProductIDTO>();

            CreateMap<Categories, CategoriesODTO>();
            CreateMap<CategoriesIDTO, Categories>();

            CreateMap<ProductAttributes, ProductAttributesODTO>();
            CreateMap<ProductAttributesIDTO, ProductAttributes>();

            CreateMap<Media, MediaODTO>();
            CreateMap<MediaIDTO, Media>();

            CreateMap<MediaType, MediaTypeODTO>();
            CreateMap<MediaTypeIDTO, MediaType>();

            CreateMap<Users, UsersODTO>()
                .ForMember(dest => dest.ImageSrc, source => source.MapFrom(m => m.Media.Src));
            CreateMap<UsersIDTO, Users>();
			CreateMap<Users, UsersIDTO>();
			CreateMap<UsersODTO, UsersIDTO>();

			CreateMap<Sale, SaleODTO>();
            CreateMap<SaleIDTO, Sale>();
            CreateMap<Sale, SaleIDTO>();

            CreateMap<Seo, SaleODTO>();
            CreateMap<Seo, SaleIDTO>();

            CreateMap<Order, OrderODTO>()
                 .ForMember(dest => dest.Email, source => source.MapFrom(m => m.Users.Email));
            CreateMap<OrderIDTO, Order>();

            CreateMap<Declaration, DeclarationODTO>();
            CreateMap<DeclarationIDTO, Declaration>();
			CreateMap<Declaration, DeclarationIDTO>();

			CreateMap<SiteContent, SiteContentODTO>();
            CreateMap<SiteContentIDTO, SiteContent>();

            CreateMap<Attributes, AttributesODTO>()
                .ForMember(dest => dest.CategoryName, source => source.MapFrom(m => m.Categories.CategoryName));
            CreateMap<AttributesIDTO, Attributes>();
        }
    }
}