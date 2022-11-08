<template>
  <form @submit.prevent="handleSubmit()">
    <div class="form-floating mb-3">
      <input type="text" class="form-control" id="Name" placeholder="Name" v-model="editable.name">
      <label for="Name">Name</label>
    </div>
    <div class="form-floating mb-3">
      <input type="url" class="form-control" id="image" placeholder="Picture" v-model="editable.picture">
      <label for="image">Picture</label>
    </div>
    <div class="form-floating mb-3">
      <input type="url" class="form-control" id="coverImage" placeholder="Cover Image" v-model="editable.coverImg">
      <label for="coverImage">Cover Image</label>
    </div>
    <div class="d-flex justify-content-between align-items-center w-100">
      <button class="btn btn-danger w-25" data-bs-dismiss="modal">Cancel</button>
      <button type="submit" class="btn btn-success w-25" data-bs-dismiss="modal">Submit</button>
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