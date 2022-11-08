<template>
  <div class="row justify-content-center">
    <div v-if="account.id && myKeeps && myVaults" class="col-8 pt-4">
      <AccountDetails :profile="account" :profileKeepsCount="myKeeps.length" :profileVaultsCount="myVaults.length" />  
    </div>
    <div class="col-12">
      <h1 class="fw-bold ms-2">Vaults</h1>
      <div class="row">
        <div v-for="v in myVaults" class="col-3">
          <VaultCard :vault="v" />
        </div>
      </div>
    </div>
    <div class="col-12">
      <h1 class="fw-bold ms-2">Keeps</h1>
      <div class="w-100 columns p-2">
        <div class="p-2" v-for="k in myKeeps" :key="k.id">
          <KeepCard :keep="k" />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
import AccountDetails from '../components/AccountDetails.vue';
import KeepCard from '../components/KeepCard.vue';
import VaultCard from '../components/VaultCard.vue';

export default {
  setup() {
    return {
      account: computed(() => AppState.account),
      myKeeps: computed(() => AppState.myKeeps),
      myVaults: computed(() => AppState.myVaults),
    };
  },
  components: { AccountDetails, KeepCard, VaultCard }
}
</script>

<style scoped>

</style>
