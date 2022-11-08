namespace Keeper.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  private readonly AccountService _accountService;
  private readonly VaultsService _vs;
  private readonly KeepsService _ks;
  private readonly Auth0Provider _auth0Provider;

  public AccountController(AccountService accountService, VaultsService vs, KeepsService ks, Auth0Provider auth0Provider)
  {
    _accountService = accountService;
    _vs = vs;
    _ks = ks;
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

  [HttpGet("keeps")]
  [Authorize]
  public async Task<ActionResult<List<Keep>>> GetKeepsByAccountId()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<Keep> keeps = _ks.GetKeepsByProfileId(userInfo.Id);
      return Ok(keeps);
    }
    catch (System.Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpPut]
  [Authorize]
  public async Task<ActionResult<Account>> updateAccount([FromBody] Account accountData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Account newAccount = _accountService.Edit(accountData, userInfo.Email);
      return Ok(newAccount);
    }
    catch (System.Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }
}
