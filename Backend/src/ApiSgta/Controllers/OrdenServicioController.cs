using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.OrdenServicioDtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiSgta.Controllers
{
    [Authorize]
    public class OrdenServicioController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrdenServicioController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<OrdenServicioDto>>> Get()
        {
            var OrdenesServicio = await _unitOfWork.OrdenesServicio.GetAllAsync();
            return _mapper.Map<List<OrdenServicioDto>>(OrdenesServicio);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrdenServicioDto>> Get(int id)
        {
            var OrdenServicio = await _unitOfWork.OrdenesServicio.GetByIdAsync(id);
            if (OrdenServicio == null)
            {
                return NotFound();
            }
            return _mapper.Map<OrdenServicioDto>(OrdenServicio);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrdenServicio>> Post(OrdenServicioDto ordenServicioDto)
        {
            var ordenServicio = _mapper.Map<OrdenServicio>(ordenServicioDto);
            _unitOfWork.OrdenesServicio.Add(ordenServicio);
            await _unitOfWork.SaveAsync();
            if (ordenServicioDto == null)
            {
                return BadRequest("OrdenServicio cannot be null");
            }
            return CreatedAtAction(nameof(Post), new { id = ordenServicioDto.Id }, ordenServicio);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] OrdenServicioDto ordenServicioDto)
        {
            if (ordenServicioDto == null || ordenServicioDto.Id != id)
            {
                return BadRequest("OrdenServicio data is invalid or ID mismatch");
            }

            var existingOrdenServicio = await _unitOfWork.OrdenesServicio.GetByIdAsync(id);
            if (existingOrdenServicio == null)
            {
                return NotFound();
            }
            _mapper.Map(ordenServicioDto, existingOrdenServicio);

            _unitOfWork.OrdenesServicio.Update(existingOrdenServicio);

            var updatedDto = _mapper.Map<OrdenServicioDto>(existingOrdenServicio);
            return Ok(updatedDto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var OrdenServicio = await _unitOfWork.OrdenesServicio.GetByIdAsync(id);
            if (OrdenServicio == null)
            {
                return NotFound();
            }

            _unitOfWork.OrdenesServicio.Remove(OrdenServicio);
            await _unitOfWork.SaveAsync();
            return Ok();
        }
    }
}