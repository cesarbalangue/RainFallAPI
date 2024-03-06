using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RainFall.components.schemas
{
    public class rainfallReadingResponse
    {
        [Required]
        [Description("Details of a rainfall reading")]
        public List<rainfallReading> items { get; set; } = new List<rainfallReading>();
    }
}
