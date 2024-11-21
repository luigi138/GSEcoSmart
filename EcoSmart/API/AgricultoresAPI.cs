using EcoSmart.Repository;
using EcoSmart.Model;
using Microsoft.AspNetCore.Mvc;

namespace EcoSmart.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnergyRecordController : ControllerBase
    {
        private readonly IEnergyRecordRepository _repository;

        public EnergyRecordController(IEnergyRecordRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var records = await _repository.GetAllAsync();
            return Ok(records);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var record = await _repository.GetByIdAsync(id);
            if (record == null)
                return NotFound();
            return Ok(record);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EnergyRecord record)
        {
            await _repository.AddAsync(record);
            return CreatedAtAction(nameof(GetById), new { id = record.Id }, record);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EnergyRecord record)
        {
            if (id != record.Id)
                return BadRequest();

            await _repository.UpdateAsync(record);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
