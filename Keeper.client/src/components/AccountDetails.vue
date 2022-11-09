<template>
  <div class="row position-relative">
    <div class="col-12">
      <img v-if="profile.coverImg" :src="profile.coverImg" alt="CoverImg" class="img-fluid w-100 h-spec rounded-3">
      <img v-else src="https://imgs.search.brave.com/DPgSAXjF6fyKVK5oNxP9f79QxxtzZzyVZvIlrEQ_BLE/rs:fit:1200:1200:1/g:ce/aHR0cHM6Ly93YWxs/cGFwZXJjYXZlLmNv/bS93cC93cDI2OTgx/MDAuanBn" alt="CoverImg" class="img-fluid h-100 rounded-3">
    </div>
    <div class="col-3 position-absolute bottom-0 start-50 profileImg">
      <img :src="profile.picture" :alt="profile.name" :title="profile.name" class="img-fluid w-100 rounded-circle shadow">
    </div>
  </div>
  <div class="row">
    <div class="col-12 d-flex justify-content-end align-items-start p-2">
      <div class="dropdown">
        <button class="btn btn-outline-secondary border-0" type="button" data-bs-toggle="dropdown" aria-expanded="false" aria-label="Edit Account Dropdown" title="Edit Account Dropdown">
          <i class="mdi mdi-dots-horizontal"></i>
        </button>
        <ul class="dropdown-menu">
          <li data-bs-toggle="modal" data-bs-target="#EditAccountModal" class="selectable ps-2" aria-label="Edit Account Button" title="Edit Account Button">Edit Account</li>
        </ul>
      </div>
    </div>
    <div class="col-12 pt-spec text-center">
      <h1>{{profile.name}}</h1>
      <p v-if="profileKeepsCount == 1 && profileVaultsCount == 1">{{profileVaultsCount}} Vault | {{profileKeepsCount}} Keep</p>
      <p v-else-if="profileVaultsCount == 1 && profileKeepsCount != 1">{{profileVaultsCount}} Vault | {{profileKeepsCount}} Keeps</p>
      <p v-else-if="profileKeepsCount != 1 && profileVaultsCount == 1">{{profileVaultsCount}} Vaults | {{profileKeepsCount}} Keep</p>
      <p v-else>{{profileVaultsCount}} Vaults | {{profileKeepsCount}} Keeps</p>
    </div>
  </div>
</template>


<script>
import { Account } from '../models/Account.js';

export default {
  props: {
    profile: { type: Account, required: true},
    profileVaultsCount: { type: Number, required: true},
    profileKeepsCount: { type: Number, required: true},
  },
  setup(){
    return {}
  }
}
</script>


<style lang="scss" scoped>
.profileImg {
  transform: translate(-50%, 50%) !important;
}

.pt-spec {
  padding-top: 6rem;
}

.h-spec {
  max-height: 30vh;
  object-fit: cover;
  object-position: center;
}
</style>