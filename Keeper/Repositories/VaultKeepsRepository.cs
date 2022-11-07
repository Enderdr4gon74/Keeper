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
    string sql = "SELECT keepId FROM vaultKeeps WHERE vaultId = 7;";
    List<int> keepIds = _db.Query<int>(sql, new { vaultId }).AsList();
    List<VaultKeepKeep> variable = new List<VaultKeepKeep>();
    // keepIds.ForEach(kId =>
    // {
    //   VaultKeepKeep keep = _keepsRepository.GetVaultKeepKeepByKeepId(kId);
    //   // FIXME - make variable have keep with id
    // });
    for (int i = 0; i < keepIds.Count; i++ ) {
      Keep keep = _keepsRepository.GetKeepById(keepIds[i]);
      VaultKeepKeep vaultKeepKeep = new VaultKeepKeep(keep);
      variable.Add(vaultKeepKeep);
    }
    return variable;
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

