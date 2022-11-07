namespace Keeper.Models;

public class VaultKeepKeep : ICreated, IRepoItem<int>
{
  public string CreatorId { get; set; }
  public Profile Creator { get; set; }
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public string Img { get; set; }
  public int Views { get; set; }
  public int Kept { get; set; }
  public int VaultKeepId { get; set; }

  public VaultKeepKeep(Keep data)
  {
    string CreatorId = data.CreatorId;
    Profile Creator = data.Creator;
    int Id = data.Id;
    DateTime CreatedAt = data.CreatedAt;
    DateTime UpdatedAt = data.UpdatedAt;
    string Name = data.Name;
    string Description = data.Description;
    string Img = data.Img;
    int Views = data.Views;
    int Kept = data.Kept;
  }
}