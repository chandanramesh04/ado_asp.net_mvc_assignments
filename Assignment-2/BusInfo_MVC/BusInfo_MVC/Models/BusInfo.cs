using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusInfo_MVC.Models
{
    public partial class BusInfo
    {
        public int BusId { get; set; }

        [RegularExpression("BGL|CHN|HYD|MUM|PUN", ErrorMessage = "BoardingPoint is incorrect")]
        [Required]
        public string? BoardingPoint { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public string? TravelDate { get; set; }

        [Required]
        public decimal? Amount { get; set; }

        [Range(1, 5, ErrorMessage = "Rating should be 1 to 5")]
        [Required]
        public int? Rating { get; set; }
    }
}
