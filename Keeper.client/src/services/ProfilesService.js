import { AppState } from "../AppState.js";
import { Keep } from "../models/Keep.js";
import { Profile } from "../models/Profile.js";
import { Vault } from "../models/Vault.js";
import { api } from "./AxiosService.js";

class ProfilesService {
  async getProfile(id) {
    AppState.profile = null
    const profile = await api.get(`/api/profiles/${id}`)
    AppState.profile = new Profile(profile.data)
  }
  
  async getProfileVaults(id) {
    AppState.profileVaults = null
    const profileVaults = await api.get(`/api/profiles/${id}/vaults`)
    // console.log(profileVaults.data)
    AppState.profileVaults = profileVaults.data.map(v => new Vault(v))
  }
  
  async getProfileKeeps(id) {
    AppState.profileKeeps = null
    const profileKeeps = await api.get(`/api/profiles/${id}/keeps`)
    // console.log(profileKeeps.data)
    AppState.profileKeeps = profileKeeps.data.map(k => new Keep(k))
  }
}

export const profilesService = new ProfilesService();