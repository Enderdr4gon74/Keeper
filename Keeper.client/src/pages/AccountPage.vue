<template>
  <div v-if="account.id && myKeeps && myVaults" class="row justify-content-center">
    <div v-if="account.id && myKeeps && myVaults" class="col-8 pt-4">
      <AccountDetails :profile="new Account(account)" :profileKeepsCount="myKeeps.length" :profileVaultsCount="myVaults.length" />  
    </div>
    <div class="col-12">
      <h1 class="fw-bold ms-2">Vaults</h1>
      <div class="w-100 columns p-2">
        <div v-for="v in myVaults"  :key="v.id">
          <VaultCard :vault="v" />
        </div>
      </div>
    </div>
    <div class="col-12">
      <h1 class="fw-bold ms-2">Keeps</h1>
      <div class="w-100 columns p-2">
        <div v-for="k in myKeeps" :key="k.id">
          <KeepCard :keep="k" />
        </div>
      </div>
    </div>
  </div>
  <div v-else class="row justify-content-center align-items-center">
    <div class="col-5">
      <img src="https://media1.giphy.com/media/3o7TKtnuHOHHUjR38Y/giphy.gif?cid=6c09b952um0m52mj4i3ec61o3vz9jy1wu7vcresa4fjvnyeu&rid=giphy.gif&ct=s" alt="loading..." class="img-fluid w-100">
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
import { Account } from '../models/Account.js'
import AccountDetails from '../components/AccountDetails.vue';
import KeepCard from '../components/KeepCard.vue';
import VaultCard from '../components/VaultCard.vue';

export default {
  setup() {
    return {
      Account: Account,
      account: computed(() => AppState.account),
      myKeeps: computed(() => AppState.myKeeps),
      myVaults: computed(() => AppState.myVaults),
    };
  },
  components: { AccountDetails, KeepCard, VaultCard }
}
</script>

<style scoped>
.columns {
  columns: 4;
}

@media screen AND (max-width: 960px) {
  .columns {
    columns: 2 !important;
  }
}

@media screen AND (max-width: 1200px) AND (min-width: 961px) {
  .columns {
    columns: 3;
  }
}
</style>
