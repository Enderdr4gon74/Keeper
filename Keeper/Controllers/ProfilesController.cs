namespace Keeper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfilesController : ControllerBase
{
  private readonly Auth0Provider _auth0provider;
  private readonly ProfilesService _ps;
  private readonly KeepsService _ks;
  private readonly VaultsService _vs;

  public ProfilesController(Auth0Provider auth0Provider, ProfilesService ps, KeepsService ks, VaultsService vs)
  {
    _auth0provider = auth0Provider;
    _ps = ps;
    _ks = ks;
    _vs = vs;
  }

  [HttpGet("{profileId}")]
  public ActionResult<Profile> GetProfileById(string profileId)
  {
    try
    {
      Profile profile = _ps.GetProfileById(profileId);
      return Ok(profile);
    }
    catch (System.Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpGet("{profileId}/keeps")]
  public ActionResult<List<Keep>> GetKeepsByProfileId(string profileId)
  {
    try
    {
      List<Keep> keeps = _ks.GetKeepsByProfileId(profileId);
      return Ok(keeps);
    }
    catch (System.Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpGet("{profileId}/vaults")]
  public ActionResult<List<Vault>> GetVaultsByProfileId(string profileId)
  {
    try
    {
      List<Vault> vaults = _vs.GetVaultsByProfileId(profileId);
      return Ok(vaults);
    }
    catch (System.Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }
}