namespace Keeper.Models;

public class VaultKeep : ICreated, IRepoItem<int>
{
  public string CreatorId { get; set; }
  public Profile Creator { get; set; }
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public int VaultId { get; set; }
  public Vault Vault { get; set; }
  public int KeepId { get; set; }
  public Keep Keep { get; set; }
}