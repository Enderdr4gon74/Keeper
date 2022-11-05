namespace Keeper.Services;

public class ProfilesService
{
  private readonly ProfilesRepository _pr;

  public ProfilesService(ProfilesRepository pr)
  {
    _pr = pr;
  }

  internal Profile GetProfileById(string profileId)
  {
    return _pr.GetProfileById(profileId);
  }
}