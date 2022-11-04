namespace Keeper.Services;

public class KeepsService 
{
  private readonly KeepsRepository _kp;

  public KeepsService( KeepsRepository kp)
  {
    _kp = kp;
  }

  internal Keep CreateKeep(Keep keepData)
  {
    return _kp.CreateKeep(keepData);
  }

  internal List<Keep> GetAllKeeps()
  {
    return _kp.GetAllKeeps();
  }

  internal Keep GetKeepById(int id)
  {
    _kp.IncrementViews(id);
    return _kp.GetKeepById(id);
  }

  internal Keep UpdateKeep(int id, Keep keepData, string userId)
  {
    Check check = CheckIfNotCreator(id, userId);
    Keep keep = check.keep;
    if (check.condition) {
      throw new Exception("You chose the wrong keep to edit foul!");
    } if (keepData.Name != null) {
      keep.Name = keepData.Name;
    } if (keepData.Description != null) {
      keep.Description = keepData.Description;
    } if (keepData.Img != null) {
      keep.Img = keepData.Img;
    }
    return _kp.UpdateKeep(keep);
  }

  private Check CheckIfNotCreator(int id, string userId)
  {
    Keep keep = _kp.GetKeepById(id);
    Boolean condition = keep.CreatorId != userId;
    Check check = new Check();
    check.condition = condition;
    check.keep = keep;
    return check;
  }

  internal void DeleteKeep(int id, string userId)
  {
    Check check = CheckIfNotCreator(id, userId);
    if (check.condition) {
      throw new Exception("You chose the wrong keep to delete foul!");
    }
    _kp.DeleteKeep(id);
  }
}