using AutoMapper;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Infrastructure.MappingProfiles
{
    public sealed class ReviewMappingProfile : Profile
    {
        public ReviewMappingProfile()
        {
            CreateMap<Review, ReviewDto>();
            CreateMap<ReviewDto, Review>()
                .ForMember(r => r.Movie, cfg => cfg.Ignore())
                .ForMember(r => r.User, cfg => cfg.Ignore());
        }
    }
}
