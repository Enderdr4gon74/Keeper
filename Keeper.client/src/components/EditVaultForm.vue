<template>
  <form @submit.prevent="handleSubmit()">
    <div class="form-floating mb-3">
      <input type="text" class="form-control" id="Name" placeholder="Name..." v-model="editable.name"  aria-label="Vault Name" title="Vault Name">
      <label for="Name">Name...</label>
    </div>
    <div class="form-floating mb-3">
      <input type="url" class="form-control" id="Img" placeholder="Image..." v-model="editable.img"  aria-label="Vault Image" title="Vault Image">
      <label for="Img">Image...</label>
    </div>
    <div class="form-floating mb-3">
      <textarea class="form-control" placeholder="Description..." id="Description" v-model="editable.description"  aria-label="Vault Description" title="Vault Description"></textarea>
      <label for="Description">Description...</label>
    </div>
    <div class="w-100 d-flex flex-column align-items-end">
      <p class="m-0 spec-text">Private Vaults can only be seen by you</p>
      <div class="form-check">
        <input class="form-check-input" type="checkbox" id="IsPrivate"  v-model="editable.isPrivate" aria-label="Is Vault Private" title="Is Vault Private">
        <label class="form-check-label" for="IsPrivate">Make Vault Private?</label>
      </div>
    </div>
    <div class="d-flex justify-content-between align-items-center w-100">
      <button class="btn btn-danger w-25" data-bs-dismiss="modal"  aria-label="Cancel Form" title="Cancel Form">Cancel</button>
      <button type="submit" class="btn btn-success w-25" data-bs-dismiss="modal" aria-label="Submit Form" title="Submit Form">Submit</button>
    </div>
  </form>
</template>


<script>
import { ref, watchEffect } from 'vue'
import { AppState } from '../AppState.js'
import { vaultsService } from '../services/VaultsService.js'
import Pop from '../utils/Pop.js'

export default {
  setup(){
    const editable = ref({})
    watchEffect(() => {
      editable.value = { ...AppState.vault }
    })
    return {
      editable,
      async handleSubmit() {
        try {
          await vaultsService.editVault(editable.value);
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