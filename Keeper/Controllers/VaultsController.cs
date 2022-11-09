namespace Keeper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VaultsController : ControllerBase
{
  private readonly Auth0Provider _auth0provider;
  private readonly VaultsService _vs;
  private readonly VaultKeepsService _vks;


  public VaultsController(Auth0Provider auth0Provider, VaultsService vs, VaultKeepsService vks)
  {
    _auth0provider = auth0Provider;
    _vs = vs;
    _vks = vks;
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Vault>> CreateVault([FromBody] Vault vaultData)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      vaultData.CreatorId = userInfo.Id;
      Vault newVault = _vs.CreateVault(vaultData);
      newVault.Creator = userInfo;
      return Ok(newVault);
    }
    catch (System.Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpGet("{id}")]
  public async  Task<ActionResult<Vault>> GetVaultById(int id)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      Vault vault;
      if (userInfo != null) {
        vault = _vs.GetVaultById(id, userInfo.Id);
      } else {
        vault = _vs.GetVaultById(id);
      }
      return Ok(vault);
    }
    catch (System.Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpGet("{id}/keeps")]
  public async Task<ActionResult<List<VaultKeepKeep>>> GetVaultKeepsByVaultId(int id)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      List<VaultKeepKeep> vaultKeeps;
      if (userInfo != null) {
        vaultKeeps = _vks.GetVaultKeepsByVaultId(id, userInfo.Id);
      } else {
        vaultKeeps = _vks.GetVaultKeepsByVaultId(id);
      }
      return Ok(vaultKeeps);
    }
    catch (System.Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpPut("{id}")]
  [Authorize]
  public async Task<ActionResult<Vault>> UpdateVault(int id, [FromBody] Vault vaultData)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      Vault newVault = _vs.UpdateVault(vaultData, userInfo.Id, id);
      return Ok(newVault);
    }
    catch (System.Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpDelete("{id}")]
  [Authorize]
  public async Task<ActionResult<Vault>> DeleteVault(int id)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      _vs.DeleteVault(id, userInfo.Id);
      return Ok("Deleted Vault");
    }
    catch (System.Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }
}