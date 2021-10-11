using AutoMapper;
using WebApplication1.Dtos;
using WebApplication1.Model;

namespace WebApplication1.Mapping
{
    public class ContactMapping : Profile
    {
        public ContactMapping()
        {
            CreateMap<Contact, ContactDto>()
                .ForMember(dto => dto.FullName, opt => opt.MapFrom(x => $"{x.Name} {x.Family}"));
                //.ForMember(entity => entity.CreationDate,
                //    opt => opt.MapFrom(x => x.CreationDate.ToPersianDate()));

            CreateMap<CreateContactDto, Contact>();
        }
    }
}
