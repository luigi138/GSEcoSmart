namespace EcoSmart.Model
{
    public class EnergyRecord
    {
        public int Id { get; set; } // 主键
        public string DeviceId { get; set; } // 设备 ID
        public decimal Amount { get; set; } // 能耗值
        public DateTime Timestamp { get; set; } // 时间戳
        public string Type { get; set; } // 类型 (如：电、水等)
    }
}
