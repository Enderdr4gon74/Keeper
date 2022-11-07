<template>
  <div v-if="activeKeep" class="col-4 p-0">
    <img :src="activeKeep.img" :alt="activeKeep.name" :title="activeKeep.name" class="img-fluid w-100 rounded-spec">
  </div>
  <div v-if="activeKeep" class="col-8 text-spec d-flex flex-column justify-content-between">
    <div class="row">
      <div class="col-3 pt-2 ps-2">
        <button @click="deleteKeep(activeKeep.id)" data-bs-dismiss="modal" v-if="activeKeep.creatorId == account.id" class="btn btn-outline-danger border-0 py-1 px-2"><i class="mdi mdi-delete-forever fs-4"></i></button>
      </div>
      <div class="col-6 d-flex justify-content-center align-items-center gap-3 py-2">
        <h4 class="m-0"><i class="mdi mdi-eye-outline"></i> {{activeKeep.views}}</h4>
        <div class="d-flex align-items-center">
          <img src="../assets/img/Keeper_Small_Logo.png" alt="Keeps" height="24">
          <h4 class="m-0">{{activeKeep.kept}}</h4>
        </div>
      </div>
      <div class="col-3 d-flex justify-content-end align-items-top pt-1 pe-1">
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
    </div>
    <div class="row">
      <div class="col-12 d-flex justify-content-center align-items-center">
        <h1>{{activeKeep.name}}</h1>
      </div>
      <div class="col-12">
        <p class="fs-4">{{activeKeep.description}}</p>
      </div>
    </div>
    <div class="row">
      <div class="col-6 d-flex justify-content-center align-items-center p-2">
        <div class="d-flex gap-2" v-if="account.id">
          <!-- TODO enter save keep form -->
        </div>
      </div>
      <div class="col-6 gap-1 py-1">
        <RouterLink :to="{name: 'Profile', params: {id: activeKeep.creatorId}}"> 
          <div data-bs-dismiss="modal" class="w-100 d-flex justify-content-end align-items-center">
            <img :src="activeKeep.creator.picture" :alt="activeKeep.creator.name" :title="activeKeep.creator.name" class="creator-img">
            <h6 class="text-dark">{{activeKeep.creator.name}}</h6>
          </div>
        </RouterLink>
      </div>
    </div>
  </div>
</template>


<script>
import { computed } from '@vue/reactivity';
import { AppState } from '../AppState.js';
import { keepsService } from '../services/KeepsService.js';
import Pop from '../utils/Pop.js';

export default {
  setup(){
    return {
      activeKeep: computed(()=> AppState.activeKeep),
      account: computed(()=> AppState.account),
      async deleteKeep(keepId) {
        try {
          await keepsService.deleteKeep(keepId)
        } catch (error) {
          Pop.error(error, "[Deleting Keep]")
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.text-spec {
  color: #636e72;
  font-family: 'Merienda', cursive;
  font-size: 24px;
}

.rounded-spec {
  border-top-left-radius: 0.5rem;
  border-bottom-left-radius: 0.5rem;
}

.creator-img {
  height: 4rem;
}
</style>