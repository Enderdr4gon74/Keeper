import { AppState } from "../AppState.js";
import { Vault } from "../models/Vault.js";
import { VaultKeep } from "../models/VaultKeep.js";
import { api } from "./AxiosService.js";

class VaultsService {
  async getVault(vaultId) {
    AppState.vault = null
    const vault = await api.get(`/api/vaults/${vaultId}`)
    AppState.vault = new Vault(vault.data);
  }

  async getVaultKeeps(vaultId) {
    AppState.vaultKeeps = null
    const vaultKeeps = await api.get(`/api/vaults/${vaultId}/keeps`)
    AppState.vaultKeeps = vaultKeeps.data.map(vK => new VaultKeep(vK))
  }
}

export const vaultsService = new VaultsService();