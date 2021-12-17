using Application.Dto.Category;
using Application.Dto.Note;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
        => new MapperConfiguration(cfg =>
        {
            #region Notes

            cfg.CreateMap<Note, NoteDto>()
                .ForMember(dest => dest.LastModified, act => act.MapFrom(src => src.Detail.LastModified));
            cfg.CreateMap<CreateNoteDto, Note>();
            cfg.CreateMap<UpdateNoteDto, Note>();
            cfg.CreateMap<IEnumerable<Note>, ListNotesDto>()
                .ForMember(dest => dest.Notes, act => act.MapFrom(src => src))
                .ForMember(dest => dest.Count, act => act.MapFrom(src => src.Count()));

            #endregion

            #region Categories

            cfg.CreateMap<Category, CategoryDto>();
            cfg.CreateMap<CreateCategoryDto, Category>();
            cfg.CreateMap<UpdateCategoryDto, Category>();

            #endregion

        }).CreateMapper();
    }
}
