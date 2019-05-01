﻿using System.Linq;
using AutoMapper;
using Stations.Models;
using Stations.DataProcessor.Dto.ImportDtos;

namespace Stations.App
{
	public class StationsProfile : Profile
	{
		// Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
		public StationsProfile()
		{
            CreateMap<StationDto, Station>();
            CreateMap<SeatingClassDto, SeatingClass>();
		}
	}
}
