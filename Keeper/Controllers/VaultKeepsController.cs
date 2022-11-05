namespace Keeper.Controllers;


[Route("api/[controller]")]
[ApiController]
public class VaultKeepsController : ControllerBase
{
  private readonly Auth0Provider _auth0provider;
  private readonly VaultKeepsService _vks;
  private readonly KeepsService _ks;
  private readonly VaultsService _vs;

  public VaultKeepsController(Auth0Provider auth0Provider, VaultKeepsService vks, KeepsService ks, VaultsService vs)
  {
    _auth0provider = auth0Provider;
    _vks = vks;
    _ks = ks;
    _vs = vs;
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<VaultKeep>> CreateVaultKeep([FromBody] VaultKeep vaultKeepData)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      vaultKeepData.CreatorId = userInfo.Id;
      VaultKeep newVaultKeep = _vks.CreateVaultKeep(vaultKeepData, userInfo.Id);
      newVaultKeep.Creator = userInfo;
      newVaultKeep.Keep = _ks.GetKeepById(newVaultKeep.KeepId);
      newVaultKeep.Vault = _vs.GetVaultById(newVaultKeep.VaultId);
      return Ok(newVaultKeep);
    }
    catch (System.Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpDelete("{vaultKeepId}")]
  public async Task<ActionResult<String>> DeleteVaultKeep(int vaultKeepId)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      _vks.DeleteVaultKeep(vaultKeepId, userInfo.Id);
      return Ok("VaultKeep was deleted");
    }
    catch (System.Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }
}