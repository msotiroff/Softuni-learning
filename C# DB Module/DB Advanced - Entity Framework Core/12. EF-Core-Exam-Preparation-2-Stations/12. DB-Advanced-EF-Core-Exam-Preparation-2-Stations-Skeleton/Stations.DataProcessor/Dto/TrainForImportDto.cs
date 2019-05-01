using Stations.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stations.DataProcessor.Dto
{
    public class TrainForImportDto
    {
        public string TrainNumber { get; set; }

        public string Type { get; set; }

        public List<SeatForImportDto> Seats { get; set; } = new List<SeatForImportDto>();
    }
}
