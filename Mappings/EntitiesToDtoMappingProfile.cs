using AutoMapper;
using VeiculosAPI.DTOs.Loja;
using VeiculosAPI.DTOs.Veiculo;
using VeiculosAPI.DTOs.Venda;
using VeiculosAPI.Models;

namespace VeiculosAPI.Mappings
{
    public class EntitiesToDtoMappingProfile : Profile {

        public EntitiesToDtoMappingProfile()
        {

            CreateMap<Loja, LojaRegisterDto>().ReverseMap();
            CreateMap<Loja, LojaUpdateDto>().ReverseMap();
            CreateMap<Loja, LojaResponseDto>().ReverseMap();

            CreateMap<Veiculo, VeiculoRegisterDto>().ReverseMap();
            CreateMap<Veiculo, VeiculoUpdateDto>().ReverseMap();
            CreateMap<Veiculo, VeiculoResponseDto>().ReverseMap();

            CreateMap<Venda, VendaUpdateDto>().ReverseMap();
            CreateMap<Venda, VendaRegisterDto>().ReverseMap();
            CreateMap<Venda, VendaResponseDto>().ReverseMap();

        }


    }
}
