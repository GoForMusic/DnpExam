using Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Data;

public class AlbumAccessDAO : IDataAccess
{
    private AlbumContext _albumContext;

    public AlbumAccessDAO(AlbumContext albumContext)
    {
        _albumContext = albumContext;
    }
    
    public async Task<Album> AddAlbumAsync(Album album)
    {
        try
        {
            await _albumContext.Albums.AddAsync(album);
            await _albumContext.SaveChangesAsync();
            return album;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<ICollection<string>> GetAlbumTitlesAsync()
    {
        try
        {
            List<Album> albums = _albumContext.Albums.ToList();
            ICollection<string> titleList = new List<string>();
            foreach (var album in albums)
            {
                titleList.Add(album.Title);
            }

            return titleList;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task AddImage(Image img, string albumTitle)
    {
        try
        {
            await _albumContext.Images.AddAsync(img);
            Album local = await _albumContext.Albums.FirstAsync(t => t.Title.Equals(albumTitle));
            local.Images.Add(img);
            _albumContext.Albums.Update(local);
            await _albumContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<ICollection<Image>> GetImagesAsync(string albumCreator, string topic)
    {
        try
        {
            Album local = new Album();
            if (albumCreator != null && topic==null)
            {
                local = await _albumContext.Albums.Include(t => t.Images).FirstAsync(t => t.CreatedBy.Equals(albumCreator));
                return local.Images;
            }else if (albumCreator == null&&topic !=null)
            {
                return _albumContext.Images.Where(t => t.Topic.Equals(topic)).ToList();
            }else if (albumCreator != null && topic != null)
            {
                local = await _albumContext.Albums.Include(t => t.Images)
                    .FirstAsync(t => t.CreatedBy.Equals(albumCreator));
                
                return local.Images.Where(t=>t.Topic.Equals(topic)).ToList();
            }

            return _albumContext.Images.ToList();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}