using API.Dtos;
using AutoMapper;
using Core.Estities;

namespace API.Profiles;

public class MappingProfiles : Profile {

    public MappingProfiles() {

        CreateMap<Pais, PaisesDto>().ReverseMap();
        CreateMap<Estado, EstadosDto>().ReverseMap();
        CreateMap<Persona, PersonasDto>().ReverseMap();
        CreateMap<PersonaProducto, EstadosDto>().ReverseMap();
        CreateMap<Producto, ProductosDto>().ReverseMap();
        CreateMap<Region, RegionesDto>().ReverseMap();
        CreateMap<TipoPersona, TipoPersonasDto>().ReverseMap();
    }

}
