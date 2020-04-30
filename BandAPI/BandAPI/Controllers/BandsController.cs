using AutoMapper;
using BandAPI.Helpers;
using BandAPI.Models;
using BandAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.Controllers
{
    [ApiController]
    [Route("api/bands")]
    public class BandsController : ControllerBase
    {
        private readonly ILibraryrepository _libraryrepository;
        private readonly IMapper _mapper;
        public BandsController(ILibraryrepository libraryrepository, IMapper mapper)
        {
            _libraryrepository = libraryrepository ??
                throw new ArgumentNullException(nameof(libraryrepository));
            _mapper=mapper??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetBands()
        {
            var bandsFromRepo = _libraryrepository.GetBands();
            //var bandsDto = new List<BandDto>();

            //foreach (var band in bandsFromRepo)
            //{
            //    bandsDto.Add(new BandDto()
            //    {
            //        Id = band.Id,
            //        Name = band.Name,
            //        MainGenre = band.MainGenre,
            //       // FoundedYearsAgo =$"{band.Founded.ToString("yyyy")} ({band.Founded.GetYearsAgo()} years ago)"
            //    });
            //}

            // return Ok(bandsFromRepo);
            return Ok(_mapper.Map<IEnumerable<BandDto>>(bandsFromRepo));
        }

        [HttpGet("{bandId}")]
        public IActionResult GetBand(Guid bandId)
        {
            //if (!_libraryrepository.BandExists(bandId))
            //    return NotFound();

            var bandFromRepo = _libraryrepository.GetBand(bandId);

            if (bandFromRepo == null)
                return NotFound();

            //return new JsonResult(bandFromRepo);
            return Ok(bandFromRepo);
        }
    }
}
