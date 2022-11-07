<template>
  <form @submit.prevent="handleSubmit()">
    <div class="form-floating mb-3">
      <input type="text" class="form-control" id="Title" placeholder="Title..." v-model="editable.Name" required>
      <label for="Title">Title...</label>
    </div>
    <div class="form-floating mb-3">
      <input type="url" class="form-control" id="ImgUrl" placeholder="ImageUrl..." v-model="editable.Img" required>
      <label for="ImgUrl">ImageUrl...</label>
    </div>
    <div class="form-floating mb-3">
      <textarea class="form-control" placeholder="Keep Description..." id="Description" v-model="editable.Description"></textarea>
      <label for="Description">Keep Description...</label>
    </div>
    <div class="d-flex justify-content-between align-items-center w-100">
      <button type="reset" class="btn btn-danger w-25" data-bs-dismiss="modal">Cancel</button>
      <button type="submit" class="btn btn-success w-25" data-bs-dismiss="modal">Submit</button>
    </div>
  </form>
</template>


<script>
import { ref } from 'vue'
import { keepsService } from '../services/KeepsService.js'
import Pop from '../utils/Pop.js'

export default {
  setup(){
    const editable = ref({})
    return {
      editable,
      async handleSubmit() {
        try {
          await keepsService.createKeep(editable.value)
          editable.value = {}
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