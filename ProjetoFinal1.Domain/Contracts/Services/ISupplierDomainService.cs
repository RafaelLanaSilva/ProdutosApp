using ProjetoFinal1.Domain.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal1.Domain.Contracts.Services
{
    public interface ISupplierDomainService
    {
        SupplierResponseDto Create(SupplierRequestDto request);
        SupplierResponseDto Update(Guid id, SupplierRequestDto request);
        SupplierResponseDto Delete(Guid id);
        List<SupplierResponseDto> GetAll();
        SupplierResponseDto? GetById(Guid id);
    }
}
