using AutoMapper;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using EntityLayer.Concrete;

namespace TraversalPresentationLayer.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
                CreateMap<AnnouncementAddDTO,Announcement>().ReverseMap();    
            
                CreateMap<AppUserRegisterDTO, AppUser>().ReverseMap();

                CreateMap<AppUserLoginDTO, AppUser>().ReverseMap();
        }
    }
}
