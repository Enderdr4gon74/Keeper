namespace Keeper.Controllers
{

  [Route("api/[controller]")]
  [ApiController]


  public class KeepsController : ControllerBase
  {
    private readonly Auth0Provider _auto0provider;
    private readonly KeepsService _ks;

    public KeepsController( Auth0Provider auth0Provider, KeepsService ks)
    {
      _auto0provider = auth0Provider;
      _ks = ks;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Keep>> CreateKeep([FromBody] Keep keepData)
    {
      try
      {
        Account userInfo = await _auto0provider.GetUserInfoAsync<Account>(HttpContext);
        keepData.CreatorId = userInfo.Id;
        Keep newKeep = _ks.CreateKeep(keepData);
        newKeep.Creator = userInfo;
        return Ok(newKeep);
      }
      catch (System.Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }


    [HttpGet]
    public ActionResult<List<Keep>> GetAllKeeps()
    {
      try
      {
        List<Keep> keeps = _ks.GetAllKeeps();
        return Ok(keeps);
      }
      catch (System.Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Keep> GetKeepById(int id)
    {
      try
      {
        Keep keep = _ks.GetKeepById(id);
        return Ok(keep);
      }
      catch (System.Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Keep>> UpdateKeep(int id, [FromBody] Keep keepData)
    {
      try
      {
        Account userInfo = await _auto0provider.GetUserInfoAsync<Account>(HttpContext);
        Keep updatedKeep = _ks.UpdateKeep(id, keepData, userInfo.Id);
        return Ok(updatedKeep);
      }
      catch (System.Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<String>> DeleteKeep(int id)
    {
      try
      {
        Account userInfo = await _auto0provider.GetUserInfoAsync<Account>(HttpContext);
        _ks.DeleteKeep(id, userInfo.Id);
        return Ok("Keep has been deleted");
      }
      catch (System.Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}