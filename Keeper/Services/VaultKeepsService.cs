namespace Keeper.Services;

public class VaultKeepsService
{
  private readonly VaultKeepsRepository _vkr;
  private readonly AccountsRepository _as;
  private readonly KeepsRepository _ks;
  private readonly VaultsRepository _vs;

  public VaultKeepsService(VaultKeepsRepository vkr, AccountsRepository @as, KeepsRepository ks, VaultsRepository vs)
  {
    _vkr = vkr;
    _as = @as;
    _ks = ks;
    _vs = vs;
  }

  internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData, string userId)
  {
    Vault vault = _vs.GetVaultById(vaultKeepData.VaultId);
    if (vault.CreatorId !=  userId) {
      throw new Exception("You chose the wrong vault to keep to foul!");
    }
    _ks.IncrementKept(vaultKeepData.KeepId); 
    return _vkr.CreateVaultKeep(vaultKeepData);
  }

  
  private Check CheckIfNotCreator(int id, string userId)
  {
    VaultKeep vaultKeep = _vkr.GetVaultKeepById(id);
    Boolean condition = vaultKeep.CreatorId != userId;
    Check check = new Check();
    check.condition = condition;
    check.vaultKeep = vaultKeep;
    return check;
  }

  internal List<VaultKeepKeep> GetVaultKeepsByVaultId(int vaultId, string userId = "")
  {
    Vault vault = _vs.GetVaultById(vaultId);
    if (vault.IsPrivate){
      if (vault.CreatorId != userId) {
        throw new Exception("Unfortunately this vault is private!");
      }
    }
    List<VaultKeepKeep> vaultKeeps = _vkr.GetVaultKeepKeepsByVaultId(vaultId);
    return vaultKeeps;
  }

  internal void DeleteVaultKeep(int vaultKeepId, string userId)
  {
    Check check = CheckIfNotCreator(vaultKeepId, userId);
    VaultKeep vaultKeep = check.vaultKeep;
    if (check.condition) {
      throw new Exception("You chose the wrong vault keep to delete foul!");
    }
    _ks.DecrementKept(vaultKeep.KeepId );
    _vkr.DeleteVaultKeep(vaultKeepId);
  }
}







    // vaultKeeps.ForEach((vaultKeep)=> {
    //   vaultKeep.Keep.Creator = _as.GetById(vaultKeep.Keep.CreatorId);
    //   vaultKeep.Vault.Creator = _as.GetById(vaultKeep.Vault.CreatorId);
    // });
    // List<VaultKeepKeep> vaultKeepKeeps = _vkr.GetVaultKeepKeepsByVaultId(vaultId);
    // // Console.WriteLine(vaultKeepKeeps.Count);
    // // for (int i = 1; i < vaultKeepKeeps.Count-1; i++) {
    // //   Console.Write(i + ", ");
    // //   vaultKeepKeeps[i].VaultKeepId = vaultKeeps[i].VaultKeepId;
    // // }
    // // List<VaultKeepKeepKeep> vaultKeepKeepKeeps = vaultKeeps.ConvertAll<VaultKeepKeepKeep>(VK => new VaultKeepKeepKeep(VK));
    // Console.WriteLine(vaultKeepKeeps);