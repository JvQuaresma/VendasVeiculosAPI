using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veiculos.Domain.DTOs.Sale;
using Veiculos.Domain.DTOs.Store;
using Veiculos.Domain.DTOs.Vehicle;
using Veiculos.Domain.Models;

namespace Veiculos.Service.Configurations.Mappings {
    public class EntitiesToDtoMappingProfile : Profile {

        public EntitiesToDtoMappingProfile() {

            CreateMap<Store, StoreRegisterDto>().ReverseMap();
            CreateMap<Store, StoreUpdateDto>().ReverseMap();
            CreateMap<Store, StoreResponseDto>().ReverseMap();

            CreateMap<Vehicle, VehicleRegisterDto>().ReverseMap();
            CreateMap<Vehicle, VehicleUpdateDto>().ReverseMap();
            CreateMap<Vehicle, VehicleResponseDto>().ReverseMap();

            CreateMap<Sale, SaleUpdateDto>().ReverseMap();
            CreateMap<Sale, SaleRegisterDto>().ReverseMap();
            CreateMap<Sale, SaleResponseDto>().ReverseMap();

        }

    }
}
