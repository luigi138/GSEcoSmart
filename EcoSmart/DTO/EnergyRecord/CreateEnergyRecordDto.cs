namespace EcoSmart.DTO.EnergyRecord
{
    public class CreateEnergyRecordDto
    {
        public string DeviceId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Timestamp { get; set; }
        public string Type { get; set; }
    }
}
