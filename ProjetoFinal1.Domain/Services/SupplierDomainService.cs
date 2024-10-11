using AutoMapper;
using ProjetoFinal1.Domain.Contracts.Repositories;
using ProjetoFinal1.Domain.Contracts.Services;
using ProjetoFinal1.Domain.Models.Dtos;
using ProjetoFinal1.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal1.Domain.Services
{
    public class SupplierDomainService : ISupplierDomainService
    {
        //attributes
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public SupplierDomainService(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public SupplierResponseDto Create(SupplierRequestDto request)
        {
            var supplier = _mapper.Map<Supplier>(request);
            supplier.Id = Guid.NewGuid();            

            _supplierRepository.Add(supplier);

            var response = _mapper.Map<SupplierResponseDto>(supplier);
            return response;
        }

        public SupplierResponseDto Update(Guid id, SupplierRequestDto request)
        {
            var supplier = _supplierRepository.GetById(id);
            if (supplier == null)
            { throw new ApplicationException("Fornecedor não encontrado. Verifique o ID informado."); }

            supplier.Name = request.Name;

            _supplierRepository.Update(supplier);

            var response = _mapper.Map<SupplierResponseDto>(supplier);
            return response;
        }

        public SupplierResponseDto Delete(Guid id)
        {
            var supplier = _supplierRepository.GetById(id);
            if (supplier == null)
            { throw new ApplicationException("Fornecedor não encontrado para exclusão. Verifique o ID informado."); }

            _supplierRepository.Delete(supplier);

            var response = _mapper.Map<SupplierResponseDto>(supplier);
            return response;
        }

        public List<SupplierResponseDto> GetAll()
        {
            var supplier = _supplierRepository.GetAll();
            var response = _mapper.Map<List<SupplierResponseDto>>(supplier);

            return response;
        }

        public SupplierResponseDto? GetById(Guid id)
        {
            var supplier = _supplierRepository.GetById(id);
            if (supplier == null)
            { throw new ApplicationException("Fornecedor não encontrado. Verifique o ID informado."); }

            var response = _mapper.Map<SupplierResponseDto>(supplier);
            return response;
        }
        
    }
}
