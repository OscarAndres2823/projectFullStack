using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs.RolUsuarioDto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiSgta.Controllers
{
    [Authorize]
    public class RolUsuarioController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RolUsuarioController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<RolUsuarioDto>>> Get()
        {
            var rolUsuarios = await _unitOfWork.RolUsuarios.GetAllAsync();
            var dtoList = _mapper.Map<List<RolUsuarioDto>>(rolUsuarios);
            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RolUsuarioDto>> Get(int id)
        {
            var rolUsuario = await _unitOfWork.RolUsuarios.GetByIdAsync(id);
            if (rolUsuario == null)
                return NotFound();

            var dto = _mapper.Map<RolUsuarioDto>(rolUsuario);
            return Ok(dto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RolUsuarioDto>> Post([FromBody] CreateRolUsuarioDto createDto)
        {
            if (createDto == null)
                return BadRequest("RolUsuario data is required");

            var rolUsuario = _mapper.Map<RolUsuario>(createDto);
            _unitOfWork.RolUsuarios.Add(rolUsuario);
            await _unitOfWork.SaveAsync();

            var createdDto = _mapper.Map<RolUsuarioDto>(rolUsuario);
            return CreatedAtAction(nameof(Get), new { id = rolUsuario.Id }, createdDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateRolUsuarioDto updateDto)
        {
            if (updateDto == null)
                return BadRequest("RolUsuario data is required");

            var existingRolUsuario = await _unitOfWork.RolUsuarios.GetByIdAsync(id);
            if (existingRolUsuario == null)
                return NotFound();

            _mapper.Map(updateDto, existingRolUsuario);
            _unitOfWork.RolUsuarios.Update(existingRolUsuario);
            await _unitOfWork.SaveAsync();

            var updatedDto = _mapper.Map<RolUsuarioDto>(existingRolUsuario);
            return Ok(updatedDto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var rolUsuario = await _unitOfWork.RolUsuarios.GetByIdAsync(id);
            if (rolUsuario == null)
                return NotFound();

            _unitOfWork.RolUsuarios.Remove(rolUsuario);
            await _unitOfWork.SaveAsync();
            return Ok();
        }
    }
}
