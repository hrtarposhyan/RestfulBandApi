using AutoMapper;
using BandAPI.Models;
using BandAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.Controllers
{
    [ApiController]
    [Route("api/bandcollections")]
    public class BandCollectionsController:ControllerBase
    {
        private readonly ILibraryrepository _libraryrepository;
        private readonly IMapper _mapper;

        public BandCollectionsController(ILibraryrepository libraryrepository, IMapper mapper)
        {
            _libraryrepository = libraryrepository ??
                throw new ArgumentNullException(nameof(libraryrepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public ActionResult<IEnumerable<BandDto>> CreateBandCollection([FromBody]
           IEnumerable<BandForCreatingDto> bandCollection)
        {
            var bandEntities = _mapper.Map<IEnumerable<Entities.Band>>(bandCollection);
            foreach (var band in bandEntities)
            {
                _libraryrepository.AddBand(band);
            }
            _libraryrepository.Save();
            return Ok();
        }
    }
}
