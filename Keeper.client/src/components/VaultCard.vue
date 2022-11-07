<template>
  <div class="w-100 p-2">
    <div class="row position-relative">
      <div class="col-12">
        <RouterLink :to="{name: 'Vault', params: {id: vault.id}}">
          <img :src="vault.img" :alt="vault.name" :title="vault.name" class="img-fluid w-100 rounded-4 selectable">
        </RouterLink>
      </div>
      <div class="col-8 position-absolute bottom-0 start-0 text-light">
        <h1 class="ms-2 text-shadow no-select keep-name">{{vault.name}}</h1>
      </div>
    </div>
  </div>
</template>


<script>
import { RouterLink } from 'vue-router';
import { Vault } from '../models/Vault.js';

export default {
    props: {
        vault: { type: Vault, required: true },
    },
    setup() {
        return {};
    },
    components: { RouterLink }
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