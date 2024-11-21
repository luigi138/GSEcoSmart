namespace EcoSmart.DTO.EnergyRecord
{
    public class EnergyRecordDto
    {
        public int Id { get; set; } // 主键
        public string DeviceId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Timestamp { get; set; }
        public string Type { get; set; }
    }
}
