using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.RepuestoDtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiSgta.Controllers
{
    [Authorize]
    public class RepuestoController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RepuestoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<RepuestoDto>>> Get()
        {
            var Repuestos = await _unitOfWork.Repuestos.GetAllAsync();
            return _mapper.Map<List<RepuestoDto>>(Repuestos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RepuestoDto>> Get(int id)
        {
            var Repuesto = await _unitOfWork.Repuestos.GetByIdAsync(id);
            if (Repuesto == null)
            {
                return NotFound();
            }
            return _mapper.Map<RepuestoDto>(Repuesto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RepuestoDto>> Post(CreateRepuestoDto createDto)

        {
            if (createDto == null)
                return BadRequest("Repuesto data is required");

            var repuesto = _mapper.Map<Repuesto>(createDto);
            _unitOfWork.Repuestos.Add(repuesto);
            await _unitOfWork.SaveAsync();

            var createdDto = _mapper.Map<RepuestoDto>(repuesto);
            return CreatedAtAction(nameof(Get), new { id = repuesto.Id }, createdDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateRepuestoDto updateDto)
        {
            if (updateDto == null)
                return BadRequest("Repuesto data is required");

            var existingRepuesto = await _unitOfWork.Repuestos.GetByIdAsync(id);
            if (existingRepuesto == null)
                return NotFound();

            _mapper.Map(updateDto, existingRepuesto);
            _unitOfWork.Repuestos.Update(existingRepuesto);
            await _unitOfWork.SaveAsync();

            var updatedDto = _mapper.Map<RepuestoDto>(existingRepuesto);
            return Ok(updatedDto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var Repuesto = await _unitOfWork.Repuestos.GetByIdAsync(id);
            if (Repuesto == null)
            {
                return NotFound();
            }

            _unitOfWork.Repuestos.Remove(Repuesto);
            await _unitOfWork.SaveAsync();
            return Ok();
        }
    }
}