import { AppState } from "../AppState.js";
import { Keep } from "../models/Keep.js";
import Pop from "../utils/Pop.js";
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

  async createKeep(keepData) {
    const newKeep = await api.post("/api/keeps", keepData)
    AppState.keeps.push(new Keep(newKeep.data))
  }

  async deleteKeep(keepId) {
    console.log(keepId)
    const data = await api.delete(`/api/keeps/${keepId}`)
    const message = data.data
    Pop.success(message)
    const keepIndex = AppState.keeps.findIndex(k => k.id == keepId);
    AppState.keeps.splice(keepIndex, 1);
  }
}

export const keepsService = new KeepsService();