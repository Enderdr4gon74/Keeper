<template>
  <div v-if="vault && vaultKeeps" class="row justify-content-center">
    <div v-if="vault && vaultKeeps" class="col-5 pt-4">
      <VaultInfo :vault="vault" :keepCount="vaultKeeps.length" />
    </div>
    <div v-if="vaultKeeps" class="col-9">
      <div class="columns">
        <VaultKeepCard v-for="k in vaultKeeps" :keep="k" />
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
import { onMounted } from 'vue';
import { useRoute } from 'vue-router';
import Pop from '../utils/Pop.js';
import { vaultsService } from "../services/VaultsService.js"
import { computed } from '@vue/reactivity';
import { AppState } from '../AppState.js';
import VaultInfo from '../components/VaultInfo.vue';
import VaultKeepCard from '../components/VaultKeepCard.vue';

export default {
  setup() {
    const route = useRoute();
    async function getVault() {
      try {
        await vaultsService.getVault(route.params.id);
      }
      catch (error) {
        Pop.error(error, "[Getting Vault]");
      }
    }
    async function getVaultKeeps() {
      try {
        await vaultsService.getVaultKeeps(route.params.id);
      }
      catch (error) {
        Pop.error(error, "[Getting Vault Keeps]");
      }
    }
    onMounted(() => {
      getVault()
      getVaultKeeps()
    });
    return {
      vault: computed(() => AppState.vault),
      vaultKeeps: computed(() => AppState.vaultKeeps),
    };
  },
  components: { VaultInfo, VaultKeepCard }
}
</script>


<style lang="scss" scoped>
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