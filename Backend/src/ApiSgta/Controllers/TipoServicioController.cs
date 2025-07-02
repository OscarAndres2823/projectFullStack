using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs.TipoServicioDtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiSgta.Controllers
{
    [Authorize]
    public class TipoServicioController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TipoServicioController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TipoServicioDto>>> Get()
        {
            var tipoServicios = await _unitOfWork.TipoServicios.GetAllAsync();
            return _mapper.Map<List<TipoServicioDto>>(tipoServicios);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoServicioDto>> Get(int id)
        {
            var tipoServicio = await _unitOfWork.TipoServicios.GetByIdAsync(id);
            if (tipoServicio == null)
                return NotFound();

            var dto = _mapper.Map<TipoServicioDto>(tipoServicio);
            return Ok(dto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoServicioDto>> Post([FromBody] CreateTipoServicioDto createDto)
        {
            if (createDto == null)
                return BadRequest();

            var tipoServicio = _mapper.Map<TipoServicio>(createDto);
            _unitOfWork.TipoServicios.Add(tipoServicio);
            await _unitOfWork.SaveAsync();

            var createdDto = _mapper.Map<TipoServicioDto>(tipoServicio);
            return CreatedAtAction(nameof(Get), new { id = tipoServicio.Id }, createdDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateTipoServicioDto updateDto)
        {
            if (updateDto == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            var existingTipoServicio = await _unitOfWork.TipoServicios.GetByIdAsync(id);
            if (existingTipoServicio == null)
                return NotFound();

            _mapper.Map(updateDto, existingTipoServicio);
            _unitOfWork.TipoServicios.Update(existingTipoServicio);
            await _unitOfWork.SaveAsync();

            var updatedDto = _mapper.Map<TipoServicioDto>(existingTipoServicio);
            return Ok(updatedDto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var tipoServicio = await _unitOfWork.TipoServicios.GetByIdAsync(id);
            if (tipoServicio == null)
                return NotFound();

            _unitOfWork.TipoServicios.Remove(tipoServicio);
            await _unitOfWork.SaveAsync();
            return Ok();
        }
    }
}
