namespace Keeper.Models;

public class Check {
  public Boolean condition { get; set; }
  public Keep keep { get; set; }
  public Vault vault { get; set; }
  public VaultKeep vaultKeep { get; set; }
}