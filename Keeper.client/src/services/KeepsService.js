import { AppState } from "../AppState.js";
import { Keep } from "../models/Keep.js";
import { api } from "./AxiosService.js";

class KeepsService {
  async getKeeps() {
    const keeps = await api.get("/api/keeps")
    AppState.keeps = keeps.data.map(k => new Keep(k))
  }

  async getActiveKeep(id) {
    AppState.activeKeep = null
    const activeKeep = await api.get(`/api/keeps/${id}`);
    AppState.activeKeep = new Keep(activeKeep.data);
  }
}

export const keepsService = new KeepsService();