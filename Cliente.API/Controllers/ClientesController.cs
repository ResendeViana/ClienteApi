using Cliente.Domain.Model;
using Cliente.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cliente.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClientesController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet()]
        public IEnumerable<ClienteModel> Get()
        {
            return _clienteRepository.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var cliente = _clienteRepository.Get(id);
            if(cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpPost()]
        public ActionResult Post(ClienteModel cliente)
        {
            try
            {
                _clienteRepository.Add(cliente);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpDelete()]
        public ActionResult Delete(int clienteId)
        {
            try
            {
                _clienteRepository.Delete(clienteId);
                return Ok();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }
        
        [HttpPut()]
        public ActionResult Update(ClienteModel cliente)
        {
            try
            {
                _clienteRepository.Update(cliente);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

    }
}
