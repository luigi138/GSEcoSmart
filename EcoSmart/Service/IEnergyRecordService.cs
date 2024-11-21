using EcoSmart.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcoSmart.Service
{
    public interface IEnergyRecordService
    {
        Task<List<EnergyRecord>> GetAllEnergyRecordsAsync();
        Task<EnergyRecord> GetEnergyRecordByIdAsync(int id);
        Task AddEnergyRecordAsync(EnergyRecord record);
        Task UpdateEnergyRecordAsync(EnergyRecord record);
        Task DeleteEnergyRecordAsync(int id);
    }
}
