namespace Keeper.Services;

public class VaultsService
{
  private readonly VaultsRepository _vp;

  public VaultsService(VaultsRepository vp)
  {
    _vp = vp;
  }

  internal Vault CreateVault(Vault vaultData)
  {
    return _vp.CreateVault(vaultData);
  }

  internal Vault GetVaultById(int id)
  {
    Vault vault = _vp.GetVaultById(id);
    // if (vault.IsPrivate){
    //   throw new Exception("Unfortunately this vault is private!");
    // }
    return vault;
  }

  internal List<Vault> GetVaultsByProfileId(string profileId)
  {
    List<Vault> vaults = _vp.GetVaultsByProfileId(profileId);
    return vaults;
  }

  internal List<Vault> GetVaultsByAccountId(string userId)
  {
    List<Vault> vaults = _vp.GetVaultsByAccountId(userId);
    return vaults;
  }

    private Check CheckIfNotCreator(int id, string userId)
  {
    Vault vault = _vp.GetVaultById(id);
    Boolean condition = vault.CreatorId != userId;
    Check check = new Check();
    check.condition = condition;
    check.vault = vault;
    return check;
  }

  internal Vault UpdateVault(Vault vaultData, string userId, int id)
  {
    Check check = CheckIfNotCreator(id, userId);
    Vault vault = check.vault;
    if (check.condition) {
      throw new Exception("You chose the wrong vault to edit foul!");
    } if (vaultData.Name != null) {
      vault.Name = vaultData.Name;
    } if (vaultData.Description != null) {
      vault.Description = vaultData.Description;
    } if (vaultData.Img != null) {
      vault.Img = vaultData.Img;
    } if (vaultData.IsPrivate != vault.IsPrivate) {
      vault.IsPrivate = vaultData.IsPrivate;
    }
    return _vp.UpdateVault(vault);
  }

  internal void DeleteVault(int id, string userId)
  {
    Check check = CheckIfNotCreator(id, userId);
    Vault vault = check.vault;
    if (check.condition) {
      throw new Exception("You chose the wrong vault to delete foul!");
    }
    _vp.DeleteVault(id);
  }
}