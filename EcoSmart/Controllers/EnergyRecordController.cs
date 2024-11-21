using EcoSmart.Service;
using EcoSmart.Model;
using EcoSmart.DTO.EnergyRecord;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoSmart.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnergyRecordController : ControllerBase
    {
        private readonly IEnergyRecordService _service;

        public EnergyRecordController(IEnergyRecordService service)
        {
            _service = service;
        }

        // GET: api/EnergyRecord
        [HttpGet]
        public async Task<ActionResult<List<EnergyRecordDto>>> GetAll()
        {
            var records = await _service.GetAllEnergyRecordsAsync();
            var result = records.Select(r => new EnergyRecordDto
            {
                Id = r.Id,
                DeviceId = r.DeviceId,
                Amount = r.Amount,
                Timestamp = r.Timestamp,
                Type = r.Type
            }).ToList();

            return Ok(result);
        }

        // GET: api/EnergyRecord/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<EnergyRecordDto>> GetById(int id)
        {
            var record = await _service.GetEnergyRecordByIdAsync(id);
            if (record == null) return NotFound();

            var result = new EnergyRecordDto
            {
                Id = record.Id,
                DeviceId = record.DeviceId,
                Amount = record.Amount,
                Timestamp = record.Timestamp,
                Type = record.Type
            };

            return Ok(result);
        }

        // POST: api/EnergyRecord
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEnergyRecordDto dto)
        {
            if (dto == null) return BadRequest("Invalid input data.");

            var record = new EnergyRecord
            {
                DeviceId = dto.DeviceId,
                Amount = dto.Amount,
                Timestamp = dto.Timestamp,
                Type = dto.Type
            };

            await _service.AddEnergyRecordAsync(record);

            var result = new EnergyRecordDto
            {
                Id = record.Id,
                DeviceId = record.DeviceId,
                Amount = record.Amount,
                Timestamp = record.Timestamp,
                Type = record.Type
            };

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // PUT: api/EnergyRecord/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateEnergyRecordDto dto)
        {
            if (id != dto.Id) return BadRequest("ID mismatch.");
            if (dto == null) return BadRequest("Invalid input data.");

            var record = new EnergyRecord
            {
                Id = dto.Id,
                DeviceId = dto.DeviceId,
                Amount = dto.Amount,
                Timestamp = dto.Timestamp,
                Type = dto.Type
            };

            await _service.UpdateEnergyRecordAsync(record);
            return NoContent();
        }

        // DELETE: api/EnergyRecord/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _service.GetEnergyRecordByIdAsync(id);
            if (record == null) return NotFound();

            await _service.DeleteEnergyRecordAsync(id);
            return NoContent();
        }
    }
}
