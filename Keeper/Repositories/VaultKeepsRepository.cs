namespace Keeper.Repositories;

public class VaultKeepsRepository : BaseRepository
{
  private readonly KeepsRepository _keepsRepository;

  public VaultKeepsRepository(IDbConnection db, KeepsRepository keepsRepository) : base(db)
  {
    _keepsRepository = keepsRepository;
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
    List<VaultKeep> vaultKeeps = _db.Query<VaultKeep, Profile, Vault, Keep, VaultKeep>(sql, (vaultKeep, profile, vault, keep) =>
    {
      vaultKeep.Creator = profile;
      vaultKeep.Vault = vault;
      vaultKeep.Keep = keep;
      vaultKeep.VaultKeepId = vaultKeep.Id;
      return vaultKeep;
    }, new { vaultId }).AsList();
    return vaultKeeps;
  }

  internal List<VaultKeepKeep> GetVaultKeepKeepsByVaultId(int vaultId)
  {
    string sql = @"
    SELECT 
      k.*,
      a.*,
      vk.*,
      vk.id as vaultKeepId
      FROM vaultKeeps vk
      JOIN keeps k on k.id = vk.keepId
      JOIN accounts a ON a.id = k.creatorId
      WHERE vaultId = @vaultId;";
    List<VaultKeepKeep> vaultKeepKeeps = _db.Query<VaultKeepKeep, Profile, VaultKeep, VaultKeepKeep>(sql, (vaultKeepKeep, profile, vaultKeep) =>
    {
      vaultKeepKeep.Creator = profile;
      vaultKeepKeep.VaultKeepId = vaultKeep.Id;
      return vaultKeepKeep;
    }, new {vaultId}).AsList();
    for (int i = 0; i < vaultKeepKeeps.Count; i++) {
      Console.WriteLine(vaultKeepKeeps[i].VaultKeepId);
      Console.WriteLine(vaultKeepKeeps[i].Id);
    }
    return vaultKeepKeeps;
  }

  internal VaultKeep GetVaultKeepById(int vaultKeepId)
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
    WHERE vk.id = @vaultKeepId;";
    List<VaultKeep> vaultKeeps = _db.Query<VaultKeep, Profile, Vault, Keep, VaultKeep>(sql, (vaultKeep, profile, vault, keep) =>
    {
      vaultKeep.Creator = profile;
      vaultKeep.Vault = vault;
      vaultKeep.Keep = keep;
      vaultKeep.VaultKeepId = vaultKeep.Id;
      return vaultKeep;
    }, new { vaultKeepId }).AsList();
    VaultKeep vaultKeep = vaultKeeps[0];
    return vaultKeep;
  }

  internal void DeleteVaultKeep(int id)
  {
    string sql = "DELETE FROM vaultKeeps WHERE id = @id";
    int rowsAffected = _db.Execute(sql, new { id });
    if (rowsAffected == 0)
    {
      throw new Exception("Unable to delete vault keep!");
    }
  }
}

