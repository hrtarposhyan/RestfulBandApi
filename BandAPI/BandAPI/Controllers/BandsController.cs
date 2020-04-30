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
        public BandsController(ILibraryrepository libraryrepository)
        {
            _libraryrepository = libraryrepository ??
                throw new ArgumentNullException(nameof(libraryrepository));
        }

        [HttpGet]
        public IActionResult GetBands()
        {
            var bandsFromRepo = _libraryrepository.GetBands();
            return Ok(bandsFromRepo);
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
