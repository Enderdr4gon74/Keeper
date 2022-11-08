import { AppState } from "../AppState.js";
import Pop from "../utils/Pop.js";
import { api } from "./AxiosService.js";

class VaultKeepsService {
  async createVaultKeep(vaultKeepData, keepId) {
    vaultKeepData.keepId = keepId.keepId;
    console.log(vaultKeepData)
    await api.post("/api/vaultKeeps", vaultKeepData)
    Pop.success("Keep has been added to Vault!")
  }

  async deleteVaultKeep(vaultKeepId) {
    if (await Pop.confirm("Are you sure you want to remove the keep from this vault?")) {
      console.log(vaultKeepId)
      await api.delete(`/api/vaultKeeps/${vaultKeepId}`)
      const vaultKeepIndex = AppState.vaultKeeps.findIndex(vk => vk.vaultKeepId == vaultKeepId)
      AppState.vaultKeeps.splice(vaultKeepIndex, 1)
      Pop.success("Keep had been removed from the Vault")
    }
  }
}

export const vaultKeepsService = new VaultKeepsService();