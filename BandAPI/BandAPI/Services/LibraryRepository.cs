using BandAPI.DBContext;
using BandAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.Services
{
    public class LibraryRepository : ILibraryrepository
    {
        private readonly LibraryContext _libraryContext;
        public LibraryRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext ?? throw new ArgumentNullException(nameof(libraryContext));
        }
        public void AddAlbum(Guid bandId, Album album)
        {
            if (bandId == Guid.Empty)
                throw new ArgumentNullException(nameof(bandId));
            if (album == null)
                throw new ArgumentNullException(nameof(album));
            album.BandId = bandId;
            _libraryContext.Albums.Add(album);
        }

        public void AddBand(Band band)
        {
            if (band == null)
                throw new ArgumentNullException(nameof(band));
            _libraryContext.Bands.Add(band);
        }

        public bool AlbumExists(Guid albumId)
        {
            if (albumId == Guid.Empty)
                throw new ArgumentNullException(nameof(albumId));

            return _libraryContext.Albums.Any(a => a.Id == albumId);
        }

        public bool BandExists(Guid bandId)
        {
            if (bandId == Guid.Empty)
                throw new ArgumentNullException(nameof(bandId));

            return _libraryContext.Bands.Any(b => b.Id == bandId);
        }

        public void DeleteAlbum(Album album)
        {
            if (album == null)
                throw new ArgumentNullException(nameof(album));

            _libraryContext.Albums.Remove(album);
        }

        public void DeleteBand(Band band)
        {
            if (band == null)
                throw new ArgumentNullException(nameof(band));

            _libraryContext.Bands.Remove(band);
        }

        public Album GetAlbum(Guid bandId, Guid albumId)
        {
            if (bandId == Guid.Empty)
                throw new ArgumentNullException(nameof(bandId));

            if (albumId == Guid.Empty)
                throw new ArgumentNullException(nameof(albumId));

            return _libraryContext.Albums.Where(a => a.BandId == bandId && a.Id == albumId).FirstOrDefault();
        }

        public IEnumerable<Album> GetAlbums(Guid bandId)
        {
            if (bandId == Guid.Empty)
                throw new ArgumentNullException(nameof(bandId));

            return _libraryContext.Albums.Where(a => a.BandId == bandId).OrderBy(a => a.Title).ToList();
        }

        public Band GetBand(Guid bandId)
        {
            if (bandId == Guid.Empty)
                throw new ArgumentNullException(nameof(bandId));

            return _libraryContext.Bands.FirstOrDefault(b => b.Id == bandId);
        }

        public IEnumerable<Band> GetBands()
        {
            return _libraryContext.Bands.ToList();
        }

        public IEnumerable<Band> GetBands(IEnumerable<Guid> bandIds)
        {
            if(bandIds==null)
                throw new ArgumentNullException(nameof(bandIds));

            return _libraryContext.Bands.Where(b => bandIds.Contains(b.Id))
                .OrderBy(b => b.Name).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Band> GetBands(string mainGenre,string searchQuery)
        {
            if (string.IsNullOrWhiteSpace(mainGenre)&& string.IsNullOrWhiteSpace(searchQuery))
                return GetBands();

            var collection=_libraryContext.Bands as IQueryable<Band>;

            if (!string.IsNullOrWhiteSpace(mainGenre))
            {
                mainGenre = mainGenre.Trim();
                collection = collection.Where(b => b.MainGenre == mainGenre);
            }

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                collection = collection.Where(b => b.Name .Contains(searchQuery));
            }

            //mainGenre = mainGenre.Trim();
            // return _libraryContext.Bands.Where(a => a.MainGenre == mainGenre).ToList();

            return collection.ToList();
        }
        public bool Save()
        {
            return (_libraryContext.SaveChanges() > 0);
        }

        public void UpdateAlbum(Album album)
        {
          // not implemented
        }

        public void UpdateBand(Band band)
        {
            // not implemented
        }
    }
}
