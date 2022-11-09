<template>
  <form @submit.prevent="handleSubmit()">
    <div class="form-floating mb-3">
      <input type="text" class="form-control" id="Title" placeholder="Title..." v-model="editable.Name" required aria-label="Vault Title" title="Vault Title">
      <label for="Title">Title...</label>
    </div>
    <div class="form-floating mb-3">
      <input type="url" class="form-control" id="ImgUrl" placeholder="Img Url..." v-model="editable.Img" required aria-label="Vault Image Url" title="Vault Image Url">
      <label for="ImgUrl">Img Url...</label>
    </div>
    <div class="form-floating mb-3">
      <textarea class="form-control" placeholder="Keep Description..." id="Description" v-model="editable.Description" aria-label="Vault Description" title="Vault Description"></textarea>
      <label for="Description">Keep Description...</label>
    </div>
    <div class="w-100 d-flex flex-column align-items-end">
      <p class="m-0 spec-text">Private Vaults can only be seen by you</p>
      <div class="form-check">
        <input class="form-check-input" type="checkbox" id="IsPrivate"  v-model="editable.IsPrivate"  aria-label="Is Vault Private?" title="Is Vault Private?">
        <label class="form-check-label" for="IsPrivate">Make Vault Private?</label>
      </div>
    </div>
    <div class="d-flex justify-content-between align-items-center w-100">
      <button type="reset" class="btn btn-danger w-25" data-bs-dismiss="modal" aria-label="Cancel Form" title="Cancel Form">Cancel</button>
      <button type="submit" class="btn btn-success w-25" data-bs-dismiss="modal" aria-label="Submit Form" title="Keep Title">Submit</button>
    </div>
  </form>
</template>


<script>
import { ref } from 'vue'
import { vaultsService } from '../services/VaultsService.js'
import Pop from '../utils/Pop.js'

export default {
  setup(){
    const editable = ref({})
    return {
      editable,
      async handleSubmit() {
        try {
          await vaultsService.createVault(editable.value)
        } catch (error) {
          Pop.error(error, "[Handling Submit]")
        }
      }
    }
  }
}
</script>
<style lang="scss" scoped>
.spec-text {
  font-size: x-small;
}
</style>