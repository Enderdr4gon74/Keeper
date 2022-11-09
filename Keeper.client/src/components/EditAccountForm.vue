<template>
  <form @submit.prevent="handleSubmit()">
    <div class="form-floating mb-3">
      <input type="text" class="form-control" id="Name" placeholder="Name" v-model="editable.name"  aria-label="Account Name" title="Account Name">
      <label for="Name">Name</label>
    </div>
    <div class="form-floating mb-3">
      <input type="url" class="form-control" id="image" placeholder="Picture" v-model="editable.picture" aria-label="Account Picture" title="Account Picture">
      <label for="image">Picture</label>
    </div>
    <div class="form-floating mb-3">
      <input type="url" class="form-control" id="coverImage" placeholder="Cover Image" v-model="editable.coverImg"  aria-label="Account Cover Image" title="Account Cover Image">
      <label for="coverImage">Cover Image</label>
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
import { accountService } from '../services/AccountService.js'
import Pop from '../utils/Pop.js'

export default {
  setup(){
    const editable = ref({})
    watchEffect(() => {
      editable.value = { name: AppState.account.name, picture: AppState.account.picture, coverImg: AppState.account.coverImg, }
    })
    return {
      editable,
      async handleSubmit() {
        try {
          await accountService.editAccount(editable.value)
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