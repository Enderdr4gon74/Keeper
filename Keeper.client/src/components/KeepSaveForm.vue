<template>
  <form @submit.prevent="handleSubmit()">
    <div class="input-group mb-3">
      <div class="form-floating">
        <select class="form-select" id="VaultPicker" v-model="editable.vaultId" required  aria-label="Save Keep To Vault" title="Save Keep To Vault">
          <option v-for="vault in myVaults" :value="vault.id">{{vault.name}}</option>
        </select>
        <label for="VaultPicker">Vaults</label>
      </div>
      <button type="submit" class="btn btn-success" data-bs-dismiss="modal"  aria-label="Submit Form And Close Modal" title="Submit Form And Close Modal">Save</button>
    </div>
  </form>
</template>


<script>
import { computed } from '@vue/reactivity'
import { ref, watchEffect } from 'vue'
import { AppState } from '../AppState.js'
import { vaultKeepsService } from '../services/VaultKeepsService.js'
import Pop from '../utils/Pop.js'

export default {
  props: {
    keepId: { type: Number, required: true},
  },
  setup(keepId){
    const editable = ref({})
    return {
      editable,
      myVaults: computed(()=> AppState.myVaults),
      async handleSubmit() {
        try {
          await vaultKeepsService.createVaultKeep(editable.value, keepId);
        } catch (error) {
          Pop.error(error, "[Handling Submit]")
        }
      }
    }
  }
}
</script>
<style lang="scss" scoped>

</style>