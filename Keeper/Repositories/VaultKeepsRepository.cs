namespace Keeper.Repositories;

public class VaultKeepsRepository : BaseRepository
{
  public VaultKeepsRepository(IDbConnection db) : base(db)
  {
  }

  internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
  {
    string sql = @"
    INSERT INTO vaultKeeps(vaultId, keepId, creatorId)
    VALUES(@VaultId, @KeepId, @CreatorId);
    SELECT LAST_INSERT_ID();";
    int vaultKeepId = _db.ExecuteScalar<int>(sql, vaultKeepData);
    vaultKeepData.Id = vaultKeepId;
    return vaultKeepData;
  }

  internal List<VaultKeep> GetVaultKeepsByVaultId(int vaultId)
  {
    string sql = @"
    SELECT
    vk.*,
    a.*,
    v.*,
    k.*
    FROM vaultKeeps vk
    JOIN accounts a ON a.id = vk.creatorId
    JOIN vaults v ON v.id = vk.vaultId
    JOIN keeps k ON k.id = vk.keepId
    WHERE vk.vaultId = @vaultId;";
    List<VaultKeep> vaultKeeps = _db.Query<VaultKeep, Profile, Vault, Keep, VaultKeep>(sql, (vaultKeep, profile, vault, keep) => {
      vaultKeep.Creator = profile;
      vaultKeep.Vault = vault;
      vaultKeep.Keep = keep;
      vaultKeep.VaultKeepId = vaultKeep.Id;
      return vaultKeep;
    }, new {vaultId}).AsList();
    return vaultKeeps;
  }
}

