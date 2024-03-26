using AutoMapper;
using BusinessLogic.Data.Entities;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using BusinessLogic.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
	internal class DataService : IDataService
	{
		private readonly IRepository<Country> countryRepository;
		private readonly IRepository<StafRole> roleRepository;
		private readonly IRepository<Genre> genreRepository;
		private readonly IRepository<Quality> qualityRepository;
		private readonly IRepository<Premium> premiumRepository;
		private readonly IMapper mapper;

		public DataService(IRepository<Country> countryRepository,
			               IRepository<StafRole> roleRepository,
						   IRepository<Genre> genreRepository,
						   IRepository<Quality> qualityRepository,
						   IRepository<Premium> premiumRepository,
						   IMapper mapper)
		{
			this.countryRepository = countryRepository;
			this.roleRepository = roleRepository;
			this.genreRepository = genreRepository;
			this.qualityRepository = qualityRepository;
			this.premiumRepository = premiumRepository;
			this.mapper = mapper;
		}

		public async Task<IEnumerable<CountryDto>> GetAllCountriesAsync()
		{
			return mapper.Map<IEnumerable<CountryDto>>(await countryRepository.GetListBySpec(new CountrySpecs.GetAll()));
		}

		public async Task<IEnumerable<GenreDto>> GetAllGenresAsync()
		{
			return mapper.Map<IEnumerable<GenreDto>>(await genreRepository.GetListBySpec(new GenreSpecs.GetAll()));
		}

		public async Task<IEnumerable<PremiumDto>> GetAllPremiumsAsync()
		{
			return mapper.Map<IEnumerable<PremiumDto>>(await premiumRepository.GetListBySpec(new PremiumSpecs.GetAll()));
		}

		public async Task<IEnumerable<QualityDto>> GetAllQualitiesAsync()
		{
			return mapper.Map<IEnumerable<QualityDto>>(await qualityRepository.GetListBySpec(new QualitySpecs.GetAll()));
		}

		public async Task<IEnumerable<StafRoleDto>> GetAllRolesAsync()
		{
			return mapper.Map<IEnumerable<StafRoleDto>>(await roleRepository.GetListBySpec(new RolesSpecs.GetAll()));
		}
	}
}
