namespace Keeper.Repositories;

public class KeepsRepository : BaseRepository
{
  public KeepsRepository(IDbConnection db) : base(db)
  {
  }

  internal Keep CreateKeep(Keep keepData)
  {
    string sql = @"
    INSERT INTO keeps(name, description, img, creatorId)
    VALUES(@Name, @Description, @Img, @CreatorId);
    SELECT LAST_INSERT_ID();";
    int id = _db.ExecuteScalar<int>(sql, keepData);
    keepData.Id = id;
    return keepData;
  }

  internal List<Keep> GetAllKeeps()
  {
    string sql = @"
    SELECT
    keep.*,
    a.*
    FROM keeps keep
    JOIN accounts a ON a.id = keep.creatorId;";
    List<Keep> keeps = _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => {
      keep.Creator = profile;
      return keep;
    }).AsList();
    return keeps;
  }

  internal Keep GetKeepById(int id)
  {
    string sql = @"
    SELECT
    keep.*,
    a.*
    FROM keeps keep
    JOIN accounts a ON a.id = keep.creatorId
    WHERE keep.id = @id;";
    List<Keep> keeps = _db.Query<Keep, Profile, Keep>(sql, (keep, profile)=> {
      keep.Creator = profile;
      return keep;
    }, new {id}).AsList();
    Keep keep = keeps[0];
    return keep;
  }

  internal void IncrementViews(int id)
  {
    string sql = "UPDATE keeps SET views = views + 1 WHERE id = @id;";
    int rowsAffected = _db.Execute(sql, new {id});
    if (rowsAffected == 0) {
      throw new Exception("Unable to increment Views!");
    }
  }

  internal Keep UpdateKeep(Keep keepData)
  {
    string sql = @"
    UPDATE keeps SET
      name = @Name,
      description = @Description,
      img = @Img
      WHERE id = @Id;";
    _db.ExecuteScalar<Keep>(sql, keepData);
    return GetKeepById(keepData.Id);
  }

  internal void DeleteKeep(int id) {
    string sql = "DELETE FROM keeps WHERE id = @id;";
    int rowsAffected = _db.Execute(sql, new {id});
    if (rowsAffected == 0) {
      throw new Exception("Unable to delete keep!");
    }
  }
}