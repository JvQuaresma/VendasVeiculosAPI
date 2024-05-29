using AutoMapper;
using VeiculosAPI.DTOs;
using VeiculosAPI.Models;

namespace VeiculosAPI.Mappings {
    public class EntitiesToDtoMappingProfile : Profile {

        public EntitiesToDtoMappingProfile()
        {

            CreateMap<Loja, LojaRegisterDto>().ReverseMap();
            CreateMap<Loja, LojaDto>().ReverseMap();

            CreateMap<Veiculo, VeiculoRegisterDto>().ReverseMap();
            CreateMap<Veiculo, VeiculoDto>().ReverseMap();

            CreateMap<Venda, VendaDto>().ReverseMap();

        }


    }
}
