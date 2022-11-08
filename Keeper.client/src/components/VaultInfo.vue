<template>
  <div class="row position-relative">
    <div class="col-12">
      <img :src="vault.img" :alt="vault.name" :title="vault.name" class="img-fluid w-100 h-spec rounded-4 elevation-2">
    </div>
    <div class="col-8 position-absolute bottom-0 start-50 translate-middle-x text-center text-light fw-3 spec-text">
      <h1 class="text-shadow-shallow">{{ vault.name }}</h1>
      <h5 class="text-shadow-shallow">by {{ vault.creator.name }}</h5>
    </div>
  </div>
  <div class="row justify-content-center pt-2">
    <div class="col-12 d-flex justify-content-between align-items-top">
      <div class="spec-text">
        <div v-if="!vault.isPrivate" class="bg-secondary rounded-pill py-2 px-3">
          <h5 class="m-0">Public</h5>
        </div>
        <div v-if="vault.isPrivate" class="bg-secondary rounded-pill py-2 px-3">
          <h5 class="m-0">Private</h5>
        </div>
      </div>
      <div class="dropdown" v-if="account.id == vault.creatorId">
        <button class="btn btn-outline-secondary border-0 spec-pad d-flex justify-content-center align-items-center"
          type="button" data-bs-toggle="dropdown" aria-expanded="false">
          <i class="mdi mdi-dots-horizontal fs-5"></i>
        </button>
        <ul class="dropdown-menu">
          <li data-bs-toggle="modal" data-bs-target="#EditVaultModal" class="dropdown-item"> Edit Vault </li>
          <li @click="deleteVault(vault.id)" class="dropdown-item text-danger"> Delete Vault </li>
        </ul>
      </div>
    </div>
    <div class="col-4">
      <div class="bg-secondary p-2 rounded-4 d-flex justify-content-center align-items-center spec-text">
        <h4 v-if="keepCount == 1" class="m-0">{{ keepCount }} Keep</h4>
        <h4 v-else class="m-0">{{ keepCount }} Keeps</h4>
      </div>
    </div>
  </div>
</template>


<script>
import { computed } from '@vue/reactivity';
import { AppState } from '../AppState.js';
import { Vault } from '../models/Vault.js';
import { vaultsService } from '../services/VaultsService.js';
import Pop from '../utils/Pop.js';

export default {
  props: {
    vault: { type: Vault, required: true },
    keepCount: { type: Number, required: true },
  },
  setup() {
    return {
      account: computed(() => AppState.account),
      async deleteVault(vaultId) {
        try {
          vaultsService.deleteVault(vaultId)
        } catch (error) {
          Pop.error(error, "[Deleting Vault]")
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.spec-text {
  font-family: 'Merienda', cursive;
}

.text-shadow {
  text-shadow: 1px 1.5px 3px #252525, -0.5px -0.75px 3px #252525;
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

.h-spec {
  max-height: 30vh;
  object-fit: cover;
  object-position: center;
}

.spec-pad {
  padding-top: 4px;
  padding-left: 10px;
  padding-bottom: 4px;
  padding-right: 10px;
}
</style>