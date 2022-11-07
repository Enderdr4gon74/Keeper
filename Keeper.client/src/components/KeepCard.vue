<template>
  <div class="w-100 p-2">
    <div class="row position-relative">
      <div class="col-12">
        <img data-bs-toggle="modal" data-bs-target="#KeepModal" @click="getActiveKeep(keep.id)" :src="keep.img" :alt="keep.name" :title="keep.name" class="img-fluid w-100 rounded-4 selectable">
      </div>
      <div class="col-8 position-absolute bottom-0 start-0 text-light">
        <h1 class="ms-2 text-shadow no-select keep-name">{{keep.name}}</h1>
      </div>
      <div class="col-2 position-absolute bottom-0 end-0 pb-1">
        <RouterLink :to="{name: 'Profile', params: {id: keep.creatorId}}">
          <img :src="keep.creator.picture" :alt="keep.creator.name" :title="keep.creator.name" class="img-fluid w-100 rounded-circle creator-picture pe-1">
        </RouterLink>
      </div>
    </div>
  </div>
</template>


<script>
import { Keep } from '../models/Keep.js';
import { keepsService } from '../services/KeepsService.js';
import Pop from '../utils/Pop.js';

export default {
  props: {
    keep: { type: Keep, required: true },
  },
  setup() {
    return {
      async getActiveKeep(id) {
        try {
          await keepsService.getActiveKeep(id);
        }
        catch (error) {
          Pop.error(error, "[Getting Active Keep]");
        }
      }
    };
  },
}
</script>


<style lang="scss" scoped>
.creator-picture {
  object-fit: cover;
  object-position: center;
}

.text-shadow {
  text-shadow: 2px 2px 3px #232323;
}

.keep-name {
  font-family: 'Merienda', cursive;
  font-size: xx-large;
}
</style>