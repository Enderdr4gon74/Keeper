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
}

