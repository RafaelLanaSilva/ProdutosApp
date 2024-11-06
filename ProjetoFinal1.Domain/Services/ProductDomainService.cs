using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Newtonsoft.Json;
using ProjetoFinal1.Domain.Contracts.Messages;
using ProjetoFinal1.Domain.Contracts.Repositories;
using ProjetoFinal1.Domain.Contracts.Services;
using ProjetoFinal1.Domain.Models.Dtos;
using ProjetoFinal1.Domain.Models.Entities;
using ProjetoFinal1.Domain.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjetoFinal1.Domain.Services
{
    public class ProductDomainService : IProductDomainService
    {
        //attributes
        private readonly IProductRepository _productRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IRabbitMQProducer _messageProducer;
        private readonly IMapper _mapper;

        //constructor for dependency injection (initialize repository interface)
        public ProductDomainService(IProductRepository productRepository, ISupplierRepository supplierRepository, IRabbitMQProducer messageProducer, IMapper mapper)
        {
            _productRepository = productRepository;
            _supplierRepository = supplierRepository;
            _messageProducer = messageProducer;
            _mapper = mapper;
        }

        public ProductResponseDto Create(ProductRequestDto request, Guid supplierId)
        {
            var product = _mapper.Map<Product>(request);
            product.Id = Guid.NewGuid();
            product.SupplierId = supplierId;

            if (_supplierRepository.GetById(supplierId) == null)
                throw new ApplicationException("Fornecedor não encontrado");

            _productRepository.Add(product);           

            //Sending the email
            var emailServiceModel = new EmailServiceModel
            {
                EmailReceiver = "rafaellanas@gmail.com",
                Subject = "Novo produto cadastrado no sistema",
                Message = $"Olá! \nO produto {product.Name} foi cadastrado com sucesso!"
            };
            _messageProducer.Send(JsonConvert.SerializeObject(emailServiceModel));

            var response = _mapper.Map<ProductResponseDto>(product);
            return response;

        }

        public ProductResponseDto Update(Guid id, ProductRequestDto request)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            { throw new ApplicationException("Produto não encontrado para edição. Verifique o ID informado."); }

                _mapper.Map(request, product);
                _productRepository.Update(product);

                var response = _mapper.Map<ProductResponseDto>(product);
                return response;
            
        }

        public ProductResponseDto Delete(Guid id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            { throw new ApplicationException("Produto não encontrado para exclusão. Verifique o ID informado."); }

                _productRepository.Delete(product);

                var response = _mapper.Map<ProductResponseDto>(product);
                return response;
            
        }

        public List<ProductResponseDto> GetAll()
        {
            var products = _productRepository.GetAll();
            var response = _mapper.Map<List<ProductResponseDto>>(products);

            return response;
        }

        public ProductResponseDto? GetById(Guid id)
        {
            var product = _productRepository.GetById(id);
            if(product == null)
                throw new ApplicationException("produto não encontrado. Verifique o ID informado.");
            var response = _mapper.Map<ProductResponseDto>(product);
            return response;

        }

    }
}
