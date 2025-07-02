using System.Threading.Tasks;
using Application.DTOs.AuditoriaDtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiSgta.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuditoriaController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuditoriaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get()
        {
            var auditorias = await _unitOfWork.Auditorias.GetAllAsync();
            var auditoriaDto = _mapper.Map<IEnumerable<AuditoriaDto>>(auditorias);
            return Ok(auditoriaDto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            var auditoria = await _unitOfWork.Auditorias.GetByIdAsync(id);
            if (auditoria == null)
            {
                return NotFound();
            }
            return Ok(auditoria);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Auditoria>> Post([FromBody] CreateAuditoriaDto auditoriaDto)
        {
            var auditoria = _mapper.Map<Auditoria>(auditoriaDto);
            _unitOfWork.Auditorias.Add(auditoria);
            await _unitOfWork.SaveAsync();
            var createdDto = _mapper.Map<AuditoriaDto>(auditoria);
            return CreatedAtAction(nameof(Get), new { id = auditoria.Id }, createdDto);

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] Auditoria auditoria)
        {
            if (auditoria == null || auditoria.Id != id)
            {
                return BadRequest("Auditoria cannot be null or ID mismatch");
            }

            var existingAuditoria = await _unitOfWork.Auditorias.GetByIdAsync(id);
            if (existingAuditoria == null)
            {
                return NotFound();
            }

            // Map propiedades recibidas sobre la entidad existente
            _mapper.Map(auditoria, existingAuditoria);

            _unitOfWork.Auditorias.Update(existingAuditoria);
            await _unitOfWork.SaveAsync();

            return Ok(auditoria);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var auditoria = await _unitOfWork.Auditorias.GetByIdAsync(id);
            if (auditoria == null)
            {
                return NotFound();
            }

            _unitOfWork.Auditorias.Remove(auditoria);
            await _unitOfWork.SaveAsync();
            return Ok();
        }
    }
}
