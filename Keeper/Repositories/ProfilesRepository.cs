namespace Keeper.Repositories;

public class ProfilesRepository : BaseRepository
{
  public ProfilesRepository(IDbConnection db) : base(db)
  {
  }

  internal Profile GetProfileById(string profileId)
  {
    string sql = "SELECT * FROM accounts WHERE id = @profileId;";
    Profile profile = _db.QueryFirstOrDefault<Profile>(sql, new {profileId});
    return profile;
  }
}