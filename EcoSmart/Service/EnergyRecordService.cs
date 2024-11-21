using EcoSmart.Model;
using EcoSmart.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcoSmart.Service
{
    public class EnergyRecordService : IEnergyRecordService
    {
        private readonly IEnergyRecordRepository _repository;

        public EnergyRecordService(IEnergyRecordRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<EnergyRecord>> GetAllEnergyRecordsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<EnergyRecord> GetEnergyRecordByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddEnergyRecordAsync(EnergyRecord record)
        {
            await _repository.AddAsync(record);
        }

        public async Task UpdateEnergyRecordAsync(EnergyRecord record)
        {
            await _repository.UpdateAsync(record);
        }

        public async Task DeleteEnergyRecordAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
