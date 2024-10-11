using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal1.Domain.Contracts.Services;
using ProjetoFinal1.Domain.Models.Dtos;
using ProjetoFinal1.Domain.Models.Entities;
using ProjetoFinal1.Domain.Models.Services;
using ProjetoFinal1.Infra.Data.Repositories;
using ProjetoFinal1.Infra.Messages.Producers;

namespace ProjetoFinal1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductDomainService _productDomainService;

        public ProductsController(IProductDomainService productDomainService)
        {
            _productDomainService = productDomainService;
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(ProductResponseDto), 201)]
        public IActionResult Post(ProductRequestDto request)
        {
            try
            {               
                var response = _productDomainService.Create(request, request.SupplierId.Value);
                
                //writing message "Produto cadastrado com sucesso!" 
                //var emailServiceModel = new EmailServiceModel();
                //emailServiceModel.EmailReceiver = "rafaellanas@gmail.com";
                //emailServiceModel.Subject = "Produto cadastrado com sucesso!";
                //emailServiceModel.Message = $"Olá, \nO produto foi cadastrado com sucesso!";

                //sending to RabbitMQ server
                //var rabbitMQProducer = new RabbitMQProducer();
                //rabbitMQProducer.Send(emailServiceModel);

                //HTTP 201 (CREATED)
                return StatusCode(201, response);
            }
            catch (ApplicationException e)
            {
                //HTTP 400 (BAD REQUEST)
                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                //HTTP 500 (INTRENAL SERVER ERROR)
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProductResponseDto), 200)]
        public IActionResult Put(Guid id, ProductRequestDto request)
        {
            try
            {
                var response = _productDomainService.Update(id, request);

                //HTTP 200 (OK)
                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                //HTTP 400 (BAD REQUEST)
                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProductResponseDto), 200)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var response = _productDomainService.Delete(id);

                //HTTP 200 (OK)
                return StatusCode(200, response);
            }
            catch(ApplicationException e)
            {
                //HTTP 400 (BAD REQUEST)
                return StatusCode(400,new { e.Message });
            }
            catch(Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ProductResponseDto>), 200)]
        public IActionResult Get()
        {
            try
            {
                var response = _productDomainService.GetAll();

                //HTTP 200 (OK)
                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                //HTTP 400(BAD RESQUEST)
                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductResponseDto), 200)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var response = _productDomainService.GetById(id);

                //HTTP 200 (OK)
                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                //HTTP 400 (BAD REQUEST)
                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new {e.Message });
            }
        }
    }
}
