namespace EcoSmart.DTO.EnergyRecord
{
    public class UpdateEnergyRecordDto
    {
        public int Id { get; set; } // 用于匹配需要更新的记录
        public string DeviceId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Timestamp { get; set; }
        public string Type { get; set; }
    }
}
