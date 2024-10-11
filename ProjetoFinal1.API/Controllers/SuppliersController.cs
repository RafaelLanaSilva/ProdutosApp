using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal1.Domain.Contracts.Services;
using ProjetoFinal1.Domain.Models.Dtos;
using ProjetoFinal1.Domain.Models.Services;

namespace ProjetoFinal1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierDomainService _supplierDomainService;

        public SuppliersController(ISupplierDomainService supplierDomainService)
        {
            _supplierDomainService = supplierDomainService;
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(SupplierResponseDto), 200)]
        public IActionResult Post(SupplierRequestDto request)
        {
            try
            {
                var Id = Guid.NewGuid();
                var response = _supplierDomainService.Create(request);

                //HTTP 201 (CREATED)
                return StatusCode(201, response);
            }
            catch (ApplicationException e)
            {
                //HTTP 400 (BAD REQUEST)
                return StatusCode(400, new {e.Message});
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(SupplierResponseDto), 200)]
        public IActionResult Put(Guid id, SupplierRequestDto request)
        {
            try
            {
                var response = _supplierDomainService.Update(id, request);

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
        [ProducesResponseType(typeof(SupplierResponseDto), 200)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var response = _supplierDomainService.Delete(id);

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

        [HttpGet]
        [ProducesResponseType(typeof(List<SupplierResponseDto>), 200)]
        public IActionResult Get()
        {
            try
            {
                var response = _supplierDomainService.GetAll();

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

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SupplierResponseDto), 200)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var response = _supplierDomainService.GetById(id);

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
    }
}
