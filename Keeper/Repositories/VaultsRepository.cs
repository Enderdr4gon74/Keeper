namespace Keeper.Repositories;

public class VaultsRepository : BaseRepository
{
  public VaultsRepository(IDbConnection db) : base(db)
  {
  }

  internal Vault CreateVault(Vault vaultData)
  {
    string sql = @"
    INSERT INTO vaults(name, description, isPrivate, img, creatorId)
    VALUES(@Name, @Description, @IsPrivate, @Img, @CreatorId);
    SELECT LAST_INSERT_ID();";
    int vaultId = _db.ExecuteScalar<int>(sql, vaultData);
    vaultData.Id = vaultId;
    return vaultData;
  }

  internal Vault GetVaultById(int id)
  {
    string sql = @"
    SELECT
    vault.*,
    a.*
    FROM vaults vault
    JOIN accounts a ON a.id = vault.creatorId
    WHERE vault.id = @id;";
    List<Vault> vaults = _db.Query<Vault, Profile, Vault>(sql, (vault, profile)=> {
      vault.Creator = profile;
      return vault;
    }, new {id}).AsList();
    Vault vault = vaults[0];
    return vault;
  }

  internal List<Vault> GetVaultsByProfileId(string profileId)
  {
    string sql = @"
    SELECT
    vault.*,
    a.*
    FROM vaults vault
    JOIN accounts a ON a.id = vault.creatorId
    WHERE vault.creatorId = @profileId;";
    List<Vault> vaults = _db.Query<Vault, Profile, Vault>(sql, (vault, profile)=> {
      vault.Creator = profile;
      return vault;
    }, new {profileId}).AsList();
    return vaults;
  }

  internal Vault UpdateVault(Vault vaultData)
  {
    string sql = @"
    UPDATE vaults SET
      name = @Name,
      description = @Description,
      img = @Img,
      isPrivate = @IsPrivate
      WHERE id = @Id;";
    _db.ExecuteScalar<Vault>(sql, vaultData);
    return GetVaultById(vaultData.Id);
  }

  internal void DeleteVault(int id)
  {
    string sql = "DELETE FROM vaults WHERE id = @id";
    int rowsAffected = _db.Execute(sql, new {id});
    if (rowsAffected == 0) {
      throw new Exception("Unable to delete vault!");
    }
  }
}