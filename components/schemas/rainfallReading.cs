using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RainFall.components.schemas
{
    public class rainfallReading
    {
        [Required]
        [Description("Details of a rainfall reading")]
        public string Id { get; set; }
        public DateTime? dateTime { get; set; } 
        public string? measure { get; set; }
        public double? value { get; set; }
    }
}
