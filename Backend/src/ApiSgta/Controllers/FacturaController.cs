using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.DetalleDtos;
using Application.DTOs.FacturaDtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiSgta.Controllers
{
    [Authorize]
    public class FacturaController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FacturaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<FacturaDto>>> Get()
        {
            var facturas = await _unitOfWork.Facturas.GetAllAsync();
            return _mapper.Map<List<FacturaDto>>(facturas);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FacturaDto>> Get(int id)
        {
            var factura = await _unitOfWork.Facturas.GetByIdAsync(id);
            if (factura == null)
            {
                return NotFound();
            }
            return _mapper.Map<FacturaDto>(factura);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Factura>> Post(CreateFacturaDto facturaDto)
        {
            if (facturaDto == null)
                return BadRequest("Factura data is required");

            var factura = _mapper.Map<Factura>(facturaDto);
            _unitOfWork.Facturas.Add(factura);
            await _unitOfWork.SaveAsync();

            var createdDto = _mapper.Map<FacturaDto>(factura);
            return CreatedAtAction(nameof(Get), new { id = factura.Id }, createdDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateFacturaDto updateDto)
        {
            if (updateDto == null)
                return BadRequest("Factura data is required");

            var existingFactura = await _unitOfWork.Facturas.GetByIdAsync(id);
            if (existingFactura == null)
                return NotFound();

            _mapper.Map(updateDto, existingFactura);

            _unitOfWork.Facturas.Update(existingFactura);
            await _unitOfWork.SaveAsync();

            var updatedDto = _mapper.Map<FacturaDto>(existingFactura);
            return Ok(updatedDto);

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var factura = await _unitOfWork.Facturas.GetByIdAsync(id);
            if (factura == null)
            {
                return NotFound();
            }

            _unitOfWork.Facturas.Remove(factura);
            await _unitOfWork.SaveAsync();
            return Ok();
        }
    }
}