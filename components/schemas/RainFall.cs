using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RainFall.components.schemas
{
    public class RainFall
    {
        [Required]
        [Description("The id of the reading station")]
        public string stationId { get; set; }
        [Range(1, 100)]
        [Description("The number of readings to return")]
        public int number { get; set; } = 10;
    }

}
