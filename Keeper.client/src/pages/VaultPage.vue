<template>
  <div class="row">
    <div class="col-4">

    </div>
    <div class="col-9">
      
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

export default {
  setup(){
    const route = useRoute();
    async function getVault() {
      try {
        await vaultsService.getVault(route.params.id)
      } catch (error) {
        Pop.error(error, "[Getting Vault]")
      }
    }
    async function getVaultKeeps() {
      try {
        await vaultsService.getVaultKeeps(route.params.id)
      } catch (error) {
        Pop.error(error, "[Getting Vault Keeps]")
      }
    }
    onMounted(()=>{
      getVault(),
      getVaultKeeps()
    })
    return {
      vault: computed(()=> AppState.vault),
      vaultKeeps: computed(()=> AppState.vaultKeeps)
    }
  }
}
</script>


<style lang="scss" scoped>

</style>