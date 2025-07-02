using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.ClienteDtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiSgta.Controllers
{
    [Authorize]
    public class ClienteController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClienteController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> Get()
        {
            var Clientes = await _unitOfWork.Clientes.GetAllAsync();
            return _mapper.Map<List<ClienteDto>>(Clientes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            var cliente = await _unitOfWork.Clientes.GetByIdAsync(id);
            if (cliente == null)
                return NotFound();

            var clienteDto = _mapper.Map<ClienteDto>(cliente);
            return Ok(clienteDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Cliente>> Post(CreateClienteDto clienteDto)
        {
            var cliente = _mapper.Map<Cliente>(clienteDto);
            _unitOfWork.Clientes.Add(cliente);
            await _unitOfWork.SaveAsync();

            var createdDto = _mapper.Map<ClienteDto>(cliente);
            return CreatedAtAction(nameof(Get), new { id = cliente.Id }, createdDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateClienteDto clienteDto)
        {
            var existingCliente = await _unitOfWork.Clientes.GetByIdAsync(id);
            if (existingCliente == null)
                return NotFound();

            _mapper.Map(clienteDto, existingCliente);
            _unitOfWork.Clientes.Update(existingCliente);
            await _unitOfWork.SaveAsync();

            var updatedDto = _mapper.Map<ClienteDto>(existingCliente);
            return Ok(updatedDto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _unitOfWork.Clientes.GetByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _unitOfWork.Clientes.Remove(cliente);
            await _unitOfWork.SaveAsync();
            return Ok();
        }
    }
}