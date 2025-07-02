using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.DetalleDtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiSgta.Controllers
{
    [Authorize]
    public class DetalleOrdenController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DetalleOrdenController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get()
        {
            var detalleOrdenes = await _unitOfWork.DetalleOrdenes.GetAllAsync();
            var detalleOrdenDto = _mapper.Map<IEnumerable<DetalleOrdenDto>>(detalleOrdenes);
            return Ok(detalleOrdenDto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DetalleOrdenDto>> Get(int id)
        {
            var detalleOrden = await _unitOfWork.DetalleOrdenes.GetByIdAsync(id);
            if (detalleOrden == null)
            {
                return NotFound();
            }
            return _mapper.Map<DetalleOrdenDto>(detalleOrden);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DetalleOrdenDto>> Post(CreateDetalleOrdenDto detalleOrdenDto)
        {
            if (detalleOrdenDto == null)
            {
                return BadRequest("DetalleOrden data is required");
            }

            var detalleOrden = _mapper.Map<DetalleOrden>(detalleOrdenDto);
            _unitOfWork.DetalleOrdenes.Add(detalleOrden);
            await _unitOfWork.SaveAsync();

            var createdDto = _mapper.Map<DetalleOrdenDto>(detalleOrden);
            return CreatedAtAction(nameof(Get), new { id = detalleOrden.Id }, createdDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateDetalleOrdenDto updateDto)
        {
            if (updateDto == null)
                return BadRequest("DetalleOrden data is required");

            var existingDetalle = await _unitOfWork.DetalleOrdenes.GetByIdAsync(id);
            if (existingDetalle == null)
                return NotFound();

            _mapper.Map(updateDto, existingDetalle);

            _unitOfWork.DetalleOrdenes.Update(existingDetalle);
            await _unitOfWork.SaveAsync();

            var updatedDto = _mapper.Map<DetalleOrdenDto>(existingDetalle);
            return Ok(updatedDto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var detalleOrden = await _unitOfWork.DetalleOrdenes.GetByIdAsync(id);
            if (detalleOrden == null)
            {
                return NotFound();
            }

            _unitOfWork.DetalleOrdenes.Remove(detalleOrden);
            await _unitOfWork.SaveAsync();
            return Ok();
        }
    }
}