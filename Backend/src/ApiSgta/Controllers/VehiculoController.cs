using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs.VehiculoDtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiSgta.Controllers
{
    [Authorize]
    public class VehiculoController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VehiculoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<VehiculoDto>>> Get()
        {
            var vehiculos = await _unitOfWork.Vehiculos.GetAllAsync();
            var dtoList = _mapper.Map<List<VehiculoDto>>(vehiculos);
            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VehiculoDto>> Get(int id)
        {
            var vehiculo = await _unitOfWork.Vehiculos.GetByIdAsync(id);
            if (vehiculo == null)
                return NotFound();

            var dto = _mapper.Map<VehiculoDto>(vehiculo);
            return Ok(dto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VehiculoDto>> Post([FromBody] CreateVehiculoDto createDto)
        {
            if (createDto == null)
                return BadRequest(ModelState);

            var vehiculo = _mapper.Map<Vehiculo>(createDto);
            _unitOfWork.Vehiculos.Add(vehiculo);
            await _unitOfWork.SaveAsync();

            var createdDto = _mapper.Map<VehiculoDto>(vehiculo);
            return CreatedAtAction(nameof(Get), new { id = vehiculo.Id }, createdDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateVehiculoDto updateDto)
        {
            if (updateDto == null)
                return BadRequest(ModelState);

            var existingVehiculo = await _unitOfWork.Vehiculos.GetByIdAsync(id);
            if (existingVehiculo == null)
                return NotFound();

            _mapper.Map(updateDto, existingVehiculo);
            _unitOfWork.Vehiculos.Update(existingVehiculo);
            await _unitOfWork.SaveAsync();

            var updatedDto = _mapper.Map<VehiculoDto>(existingVehiculo);
            return Ok(updatedDto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var vehiculo = await _unitOfWork.Vehiculos.GetByIdAsync(id);
            if (vehiculo == null)
                return NotFound();

            _unitOfWork.Vehiculos.Remove(vehiculo);
            await _unitOfWork.SaveAsync();
            return Ok();
        }
    }
}
