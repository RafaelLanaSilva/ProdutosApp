using AutoMapper;
using ProjetoFinal1.Domain.Models.Dtos;
using ProjetoFinal1.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal1.Domain.Mappings
{
    public class ProfileMap : Profile
    {
        //constructor method
        public ProfileMap()
        {
            CreateMap<ProductRequestDto, Product>();
            CreateMap<Product, ProductResponseDto>();

            CreateMap<SupplierRequestDto, Supplier>();
            CreateMap<Supplier, SupplierResponseDto>();
        }
    }
}
