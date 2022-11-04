namespace Keeper.Services;

public class VaultKeepsService
{
  private readonly VaultKeepsRepository _vkr;

  public VaultKeepsService(VaultKeepsRepository vkr)
  {
    _vkr = vkr;
  }

  internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
  {
    return _vkr.CreateVaultKeep(vaultKeepData);
  }
}