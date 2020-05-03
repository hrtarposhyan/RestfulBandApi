using AutoMapper;
using BandAPI.Models;
using BandAPI.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.Controllers
{
    [ApiController]
    [Route("api/bands/{bandId}/albums")]
    public class AlbumsController : ControllerBase
    {
        private readonly ILibraryrepository _libraryrepository;
        private readonly IMapper _mapper;
        public AlbumsController(ILibraryrepository libraryrepository, IMapper mapper)
        {
            _libraryrepository = libraryrepository ??
                throw new ArgumentNullException(nameof(libraryrepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<AlbumsDto>> GetAlbumsForBand(Guid bandId)
        {
            if (!_libraryrepository.BandExists(bandId))
                return NotFound();

            var albumsFromRepo = _libraryrepository.GetAlbums(bandId);
            return Ok(_mapper.Map<IEnumerable<AlbumsDto>>(albumsFromRepo));
        }
        [HttpGet("{albumId}", Name = "GetAlbumForBand")]
        public ActionResult<AlbumsDto> GetAlbumForBand(Guid bandId, Guid albumId)
        {
            if (!_libraryrepository.BandExists(bandId))
                return NotFound();

            var albumFromrepo = _libraryrepository.GetAlbum(bandId, albumId);
            if (albumFromrepo == null)
                return NotFound();

            return Ok(_mapper.Map<AlbumsDto>(albumFromrepo));
        }

        [HttpPost]
        public ActionResult<AlbumsDto> CreateAlbumForBand(Guid bandId, [FromBody]
            AlbumForCreatingDto album)
        {
            if (!_libraryrepository.BandExists(bandId))
                return NotFound();

            var albumEntity = _mapper.Map<Entities.Album>(album);
            _libraryrepository.AddAlbum(bandId, albumEntity);
            _libraryrepository.Save();

            var albumToReturn = _mapper.Map<AlbumsDto>(albumEntity);
            return CreatedAtRoute("GetAlbumForBand", new { bandId = bandId, albumId = albumToReturn.Id }, 
                albumToReturn);
        }

        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdateAlbumForBand(Guid bandId, Guid id,
            [FromBody] JsonPatchDocument<AlbumForUpdatingDto> patchDoc)
        {
            if (patchDoc == null)
                return BadRequest();

            if (!_libraryrepository.BandExists(bandId))
                return NotFound();

            var albumForBandFromRepo = _libraryrepository.GetAlbum(bandId, id);
            if (albumForBandFromRepo == null)
                return NotFound();

            var albumToPatch = _mapper.Map<AlbumForUpdatingDto>(albumForBandFromRepo);
            patchDoc.ApplyTo(albumToPatch);

            // add validation

            _mapper.Map(albumToPatch, albumForBandFromRepo);
            _libraryrepository.UpdateAlbum(albumForBandFromRepo);

            if (!_libraryrepository.Save())
            {
                throw new Exception($"Patching album {id} for band {bandId} failed on save");
            }

            return NoContent();
        }
    }
}
