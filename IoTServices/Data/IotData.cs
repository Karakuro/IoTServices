using System.ComponentModel.DataAnnotations;

namespace IoTServices.Data
{
    public class IotData
    {
        [Key]
        public int Id { get; set; }
        public int IdDevice { get; set; }
        public float Temperatura { get; set; }
        public float Umidita { get; set; }
        public float Pressione { get; set; }
        public float Altitudine { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
