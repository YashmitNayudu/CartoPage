using System.ComponentModel.DataAnnotations;

namespace CartoPageCFDNIE.Models
{
    public class Map
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public float lat { get; set; } 
        public float lon { get; set; }
    }
}
