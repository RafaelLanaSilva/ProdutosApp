using ProjetoFinal1.Domain.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal1.Domain.Contracts.Services
{
    public interface IProductDomainService
    {
        ProductResponseDto Create(ProductRequestDto request, Guid supplierId);
        ProductResponseDto Update(Guid id, ProductRequestDto request);
        ProductResponseDto Delete(Guid id);
        List<ProductResponseDto> GetAll();
        ProductResponseDto? GetById(Guid id);
       
    }
}
