using Entities;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ImagesController :ControllerBase
{
    private IDataAccess _dataAccess;

    public ImagesController(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<Image>>> GetImages([FromQuery] string? albumCreator,[FromQuery] string? topic)
    {
        try
        {
            return Ok(await _dataAccess.GetImagesAsync(albumCreator,topic));
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

}