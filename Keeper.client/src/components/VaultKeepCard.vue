<template>
  <div class="w-100 p-2">
    <div class="row position-relative">
      <div class="col-12">
        <img data-bs-toggle="modal" data-bs-target="#KeepModal" @click="getActiveKeep(keep.id)" :src="keep.img" :alt="keep.name" :title="keep.name" class="img-fluid w-100 rounded-4 selectable elevation-2"  aria-label="Show Keep Details" title="Show Keep Details">
      </div>
      <div class="col-8 position-absolute bottom-0 start-0 text-light">
        <h1 class="ms-2 text-shadow-shallow no-select keep-name">{{keep.name}}</h1>
      </div>
      <div class="col-3 position-absolute bottom-0 end-0 pb-1">
        <RouterLink :to="{name: 'Profile', params: {id: keep.creatorId}}"  aria-label="To Creator Profile Page" title="To Creator Profile Page">
          <img :src="keep.creator.picture" :alt="keep.creator.name" :title="keep.creator.name" class="img-fluid w-100 rounded-circle creator-picture pe-1 elevation-2">
        </RouterLink>
      </div>
      <div class="col-3 ps-2 position-absolute top-0 end-0" v-if="keep.creator.id == account.id">
        <div class="pt-1">
          <button @click="deleteVaultKeep(keep.vaultKeepId)" class="btn btn-outline-danger border-0 rounded-4 py-1 px-2" aria-label="Remove Keep From Vault" title="Remove Keep From Vault"><i class="mdi mdi-delete-forever text-shadow-shallow"></i></button>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { computed } from '@vue/reactivity';
import { AppState } from '../AppState.js';
import { VaultKeep } from '../models/VaultKeep.js';
import { keepsService } from '../services/KeepsService.js';
import { vaultKeepsService } from '../services/VaultKeepsService.js';
import Pop from '../utils/Pop.js';

export default {
  props: {
    keep: { type: VaultKeep, required: true },
  },
  setup() {
    return {
      account: computed(()=>AppState.account),
      async getActiveKeep(id) {
        try {
          await keepsService.getActiveKeep(id);
        }
        catch (error) {
          Pop.error(error, "[Getting Active Keep]");
        }
      },
      async deleteVaultKeep(vaultKeepId) {
        try {
          await vaultKeepsService.deleteVaultKeep(vaultKeepId);
        }
        catch (error) {
          Pop.error(error, "[Getting Active Keep]");
        }
      },
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

.text-shadow-shallow {
  text-shadow: 
    0px 2px 5px #13131360, 
    2px 2px 5px #13131360, 
    2px 0px 5px #13131360, 
    2px -2px 5px #13131360, 
    0px -2px 5px #13131360,
    -2px -2px 5px #13131360,
    -2px 0px 5px #13131360, 
    -2px 2px 5px #13131360; 
}

.keep-name {
  font-family: 'Merienda', cursive;
  font-size: xx-large;
}
</style>