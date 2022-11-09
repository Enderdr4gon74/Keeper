import { AppState } from "../AppState.js";
import { Vault } from "../models/Vault.js";
import { VaultKeep } from "../models/VaultKeep.js";
import { router } from "../router.js";
import Pop from "../utils/Pop.js";
import { api } from "./AxiosService.js";

class VaultsService {
  async getVault(vaultId) {
    AppState.vault = null
    const vault = await api.get(`/api/vaults/${vaultId}`)
    const newVault = new Vault(vault.data)
    AppState.vault = new Vault(vault.data);
    // if (newVault.isPrivate) {
    //   if (AppState.account.id) {
    //     if (AppState.account.id == newVault.creatorId) {
    //       // If vault is private, user is logged in, and the user is the creator of the vault
    //       AppState.vault = new Vault(vault.data);
    //     } else {
    //       // If vault is private, user is logged in, and the user is not the creator of the vault
    //       router.push({name: "Home"})
    //       Pop.toast("Unfortunately that vault is private", "warning")
    //     }
    //   } else {
    //     // If vault is private and the user is not logged in
    //     router.push({name: "Home"})
    //     Pop.toast("Unfortunately that vault is private", "warning")
    //   }
    // } else {
    //   // if the vault is public
    //   AppState.vault = new Vault(vault.data);
    // }
  }

  async getMyVaults() {
    AppState.myVaults = null;
    const myVaults = await api.get('/account/vaults');
    AppState.myVaults = myVaults.data.map(v => new Vault(v));
  }

  async getVaultKeeps(vaultId) {
    AppState.vaultKeeps = null
    const vaultKeeps = await api.get(`/api/vaults/${vaultId}/keeps`)
    AppState.vaultKeeps = vaultKeeps.data.map(vK => new VaultKeep(vK))
  }

  async createVault(vaultData) {
    console.log(vaultData)
    const newVault = await api.post("/api/vaults", vaultData)
    AppState.myVaults.push(new Vault(newVault.data))
    // TODO possibly router push to new vault page
    // TODO possibly add if statements that make new vault appear
  }

  async editVault(vaultData) {
    // console.log(vaultData)
    const newVault = await api.put(`/api/vaults/${vaultData.id}`, vaultData)
    const newerVault = new Vault(newVault.data)
    AppState.vault = newerVault;
    const vaultIndex = AppState.myVaults.findIndex(v => v.id == newerVault.id)
    // console.log(newerVault)
    // console.log(vaultIndex)
    // console.log(AppState.myVaults[vaultIndex])
    AppState.myVaults.splice(vaultIndex, 1, newerVault)
    // console.log(AppState.myVaults[vaultIndex])
  }

  async deleteVault(vaultId) {
    if (await Pop.confirm("Are You Sure you want to delete this vault")) {
      await api.delete(`/api/vaults/${vaultId}`)
      const vaultIndex = AppState.myVaults.findIndex(v => v.id == vaultId)
      AppState.myVaults.splice(vaultIndex, 1)
      router.push({name: "Home"})
      Pop.toast(" Vault Deleted ", "success")
    }
  }
}

export const vaultsService = new VaultsService();