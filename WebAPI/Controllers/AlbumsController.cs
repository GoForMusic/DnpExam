using Entities;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AlbumsController : ControllerBase
{
    private IDataAccess _dataAccess;

    public AlbumsController(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    [HttpPost]
    public async Task<ActionResult<Album>> CreateAlbum([FromBody]Album album)
    {
        try
        {
            return Ok(await _dataAccess.AddAlbumAsync(album));
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    [Route("titles")]
    public async Task<ActionResult<ICollection<string>>> GetTitles()
    {
        try
        {
            return Ok(await _dataAccess.GetAlbumTitlesAsync());
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    [Route("image/{title}")]
    public async Task<ActionResult> AddImageToAlbum([FromBody]Image img, [FromRoute] string title)
    {
        try
        {
            await _dataAccess.AddImage(img, title);
            return Ok("Images has been added");
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

}