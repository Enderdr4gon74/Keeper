import { Keep } from "./Keep.js"
import { Profile } from "./Profile.js"
import { Vault } from "./Vault.js"

export class VaultKeep {
  constructor(data) {
    this.creatorId = data.creatorId
    this.creator = new Profile(data.creator)
    this.id = data.id
    this.vaultKeepId = data.vaultKeepId
    this.createdAt = data.createdAt
    this.updatedAt = data.updatedAt
    this.vaultId = data.vaultId
    this.vault = new Vault(data.vault)
    this.keepId = data.keepId
    this.keep = new Keep(data.keep)
  }
}