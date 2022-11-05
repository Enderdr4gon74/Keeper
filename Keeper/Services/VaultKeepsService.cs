namespace Keeper.Services;

public class VaultKeepsService
{
  private readonly VaultKeepsRepository _vkr;
  private readonly AccountsRepository _as;

  public VaultKeepsService(VaultKeepsRepository vkr, AccountsRepository @as)
  {
    _vkr = vkr;
    _as = @as;
  }

  internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
  {
    return _vkr.CreateVaultKeep(vaultKeepData);
  }

  internal List<VaultKeep> GetVaultKeepsByVaultId(int vaultId)
  {
    List<VaultKeep> vaultKeeps = _vkr.GetVaultKeepsByVaultId(vaultId);
    vaultKeeps.ForEach((vaultKeep)=> {
      vaultKeep.Keep.Creator = _as.GetById(vaultKeep.Keep.CreatorId);
      vaultKeep.Vault.Creator = _as.GetById(vaultKeep.Vault.CreatorId);
    });
    return vaultKeeps;
  }
}