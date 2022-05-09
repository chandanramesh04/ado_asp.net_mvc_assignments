using System;
using System.Collections.Generic;

namespace BusDetails_TableDisplay.Models
{
    public partial class BusInfo
    {
        public int BusId { get; set; }
        public string? BoardingPoint { get; set; }
        public string? TravelDate { get; set; }
        public decimal? Amount { get; set; }
        public int? Rating { get; set; }
    }
}
