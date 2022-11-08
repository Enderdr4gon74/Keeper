<template>
  <div class="row justify-content-center">
    <div v-if="vault && vaultKeeps" class="col-5 pt-4">
      <VaultInfo :vault="vault" :keepCount="vaultKeeps.length" />
    </div>
    <div v-if="vaultKeeps" class="col-9">
      <div class="columns">
        <KeepCard v-for="k in vaultKeeps" :keep="k" />
      </div>
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
import KeepCard from '../components/KeepCard.vue';

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
  components: { VaultInfo, KeepCard }
}
</script>


<style lang="scss" scoped>
.columns {
  columns: 4;
}

@media screen AND (max-width: 720px) {
  .columns {
    columns: 1 !important;
  }
}

@media screen AND (max-width: 960px) AND (min-width: 721px) {
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