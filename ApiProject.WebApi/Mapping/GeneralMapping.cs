using ApiProject.WebApi.Dtos.CategoryDtos;
using ApiProject.WebApi.Dtos.FeatureDtos;
using ApiProject.WebApi.Dtos.MessageDtos;
using ApiProject.WebApi.Dtos.NotificationDtos;
using ApiProject.WebApi.Dtos.ProductDtos;
using ApiProject.WebApi.Entities;
using AutoMapper;

namespace ApiProject.WebApi.Mapping
{
    //sınıf bazında eşleşmeler yapılır mappingde
    public class GeneralMapping :Profile
    {
        //auto mapperda maplenecek ifadeler constructure içinde yazılır
        public GeneralMapping()
        {
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();

            CreateMap<Message, ResultMessageDto>().ReverseMap();
            CreateMap<Message, CreateMessageDto>().ReverseMap();
            CreateMap<Message, GetByIdMessageDto>().ReverseMap();
            CreateMap<Message,  UpdateMessageDto>().ReverseMap();   

            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductWithCategoryDto>()
                .ForMember(x=>x.CategoryName, y=>y.MapFrom(z=>z.Category.CategoryName)).ReverseMap();

            CreateMap<Notification, ResultNotificationDto>().ReverseMap();
            CreateMap<Notification, CreateNotificationDto>().ReverseMap();
            CreateMap<Notification, GetNotificationByIdDto>().ReverseMap();
            CreateMap<Notification, UpdateNotificationDto>().ReverseMap();

            CreateMap<Category, CreateCategoryDto>().ReverseMap();
        }
    }
}
