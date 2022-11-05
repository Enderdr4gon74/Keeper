namespace Keeper.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  private readonly AccountService _accountService;
  private readonly VaultsService _vs;
  private readonly Auth0Provider _auth0Provider;

  public AccountController(AccountService accountService, VaultsService vs, Auth0Provider auth0Provider)
  {
    _accountService = accountService;
    _vs = vs;
    _auth0Provider = auth0Provider;
  }

  [HttpGet]
  [Authorize]
  public async Task<ActionResult<Account>> Get()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateProfile(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("vaults")]
  [Authorize]
  public async Task<ActionResult<List<Vault>>> GetVaultsByAccountId()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<Vault> vaults = _vs.GetVaultsByAccountId(userInfo.Id);
      return Ok(vaults);
    }
    catch (System.Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }
}
