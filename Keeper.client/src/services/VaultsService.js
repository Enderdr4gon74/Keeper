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
    if (AppState.account.id) {
      if (newVault.isPrivate && AppState.account.id != newVault.creatorId) {
        router.push({name: "Home"})
        Pop.toast("Unfortunately that vault is private", "warning")
      } else {
        AppState.vault = new Vault(vault.data);
      }
    } else {
      router.push({name: "Home"})
      Pop.toast("Unfortunately that vault is private", "warning")
    }
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
    await api.post("/api/vaults", vaultData)
    // TODO possibly router push to new vault page
    // TODO possibly add if statements that make new vault appear
  }
}

export const vaultsService = new VaultsService();