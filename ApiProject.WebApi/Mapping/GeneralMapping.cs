using ApiProject.WebApi.Dtos.FeatureDtos;
using ApiProject.WebApi.Dtos.MessageDtos;
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
            CreateMap<Feature, CreateFutureDto>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();

            CreateMap<Message, ResultMessageDto>().ReverseMap();
            CreateMap<Message, CreateMessageDto>().ReverseMap();
            CreateMap<Message, GetByIdMessageDto>().ReverseMap();
            CreateMap<Message,  UpdateMessageDto>().ReverseMap();   

            CreateMap<Product, CreateProductDto>().ReverseMap();
        }
    }
}
