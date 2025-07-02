using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs.UsuarioDtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiSgta.Controllers
{
    [Authorize]
    public class UsuarioController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsuarioController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> Get()
        {
            var usuarios = await _unitOfWork.Usuarios.GetAllAsync();
            var dtoList = _mapper.Map<List<UsuarioDto>>(usuarios);
            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UsuarioDto>> Get(int id)
        {
            var usuario = await _unitOfWork.Usuarios.GetByIdAsync(id);
            if (usuario == null)
                return NotFound();

            var dto = _mapper.Map<UsuarioDto>(usuario);
            return Ok(dto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UsuarioDto>> Post([FromBody] CreateUsuarioDto createDto)
        {
            if (createDto == null)
                return BadRequest();

            var usuario = _mapper.Map<Usuario>(createDto);
            _unitOfWork.Usuarios.Add(usuario);
            await _unitOfWork.SaveAsync();

            var createdDto = _mapper.Map<UsuarioDto>(usuario);
            return CreatedAtAction(nameof(Get), new { id = usuario.Id }, createdDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateUsuarioDto updateDto)
        {
            if (updateDto == null)
                return BadRequest();

            var existingUsuario = await _unitOfWork.Usuarios.GetByIdAsync(id);
            if (existingUsuario == null)
                return NotFound();

            _mapper.Map(updateDto, existingUsuario);
            _unitOfWork.Usuarios.Update(existingUsuario);
            await _unitOfWork.SaveAsync();

            var updatedDto = _mapper.Map<UsuarioDto>(existingUsuario);
            return Ok(updatedDto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _unitOfWork.Usuarios.GetByIdAsync(id);
            if (usuario == null)
                return NotFound();

            _unitOfWork.Usuarios.Remove(usuario);
            await _unitOfWork.SaveAsync();

            return Ok();
        }
    }
}
