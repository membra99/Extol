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
			CreateMap<Product, ProductODTO>()
				.ForMember(dest => dest.LanguageName, source => source.MapFrom(m => m.Language.LanguageName));
			CreateMap<ProductIDTO, Product>();
			CreateMap<ProductODTO, ProductIDTO>();

			CreateMap<Categories, CategoriesODTO>()
				.ForMember(dest => dest.GoogleDesc, source => source.MapFrom(m => m.Seo.GoogleDesc))
				.ForMember(dest => dest.GoogleKeywords, source => source.MapFrom(m => m.Seo.GoogleKeywords))
				.ForMember(dest => dest.LanguageName, source => source.MapFrom(m => m.Languages.LanguageName));
			CreateMap<CategoriesIDTO, Categories>();

			CreateMap<ProductAttributes, ProductAttributesODTO>();
			CreateMap<ProductAttributesIDTO, ProductAttributes>();

			CreateMap<Media, MediaODTO>();
			CreateMap<MediaIDTO, Media>();

			CreateMap<Tag, TagODTO>()
				.ForMember(dest => dest.LanguageName, source => source.MapFrom(m => m.Language.LanguageName));

			CreateMap<Invoice, InvoiceEntitiesODTO>()
				.ForMember(dest => dest.Src, source => source.MapFrom(m => m.Media.Src));
			CreateMap<InvoiceEntitiesIDTO, Invoice>();

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

			CreateMap<Seo, SeoODTO>()
				.ForMember(dest => dest.LanguageName, source => source.MapFrom(m => m.Language.LanguageName));
			CreateMap<Seo, SeoIDTO>();
			CreateMap<SeoIDTO, Seo>();

			CreateMap<Order, OrderODTO>()
				 .ForMember(dest => dest.Email, source => source.MapFrom(m => m.Users.Email));
			CreateMap<OrderIDTO, Order>();

			CreateMap<Declaration, DeclarationODTO>()
				.ForMember(dest => dest.LanguageName, source => source.MapFrom(m => m.Language.LanguageName));
			CreateMap<DeclarationIDTO, Declaration>();
			CreateMap<Declaration, DeclarationIDTO>();

			CreateMap<SiteContent, SiteContentODTO>()
				.ForMember(dest => dest.LanguageName, source => source.MapFrom(m => m.Language.LanguageName));
			CreateMap<SiteContentIDTO, SiteContent>();

			CreateMap<Attributes, AttributesODTO>()
				.ForMember(dest => dest.CategoryName, source => source.MapFrom(m => m.Categories.CategoryName));
			CreateMap<AttributesIDTO, Attributes>();

			CreateMap<Language, LanguageODTO>();
			CreateMap<LanguageIDTO, Language>();
		}
	}
}