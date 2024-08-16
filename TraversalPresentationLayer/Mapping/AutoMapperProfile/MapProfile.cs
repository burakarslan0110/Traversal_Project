using AutoMapper;
using DTOLayer.DTOs.AdminDTOs;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;

namespace TraversalPresentationLayer.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {   
                CreateMap<AppUserRegisterDTO, AppUser>().ReverseMap();

                CreateMap<AppUserLoginDTO, AppUser>().ReverseMap();

                CreateMap<EditUserDTO, AppUser>().ReverseMap();

                CreateMap<AnnouncementListDTO, Announcement>().ReverseMap();

                CreateMap<AnnouncementAddDTO, Announcement>().ReverseMap();

                CreateMap<AnnouncementEditDTO, Announcement>().ReverseMap();

                CreateMap<SendMessageDTO, ContactUs>().ReverseMap();
        }
    }
}
