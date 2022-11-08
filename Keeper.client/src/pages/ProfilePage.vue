<template>
  <div v-if="profile && profileKeeps && profileVaults" class="row justify-content-center py-2">
    <div v-if="profile && profileKeeps && profileVaults" class="col-8">
      <ProfileDetails :profile="profile" :profileKeepsCount="profileKeeps.length" :profileVaultsCount="profileVaults.length" />
    </div>
    <div class="col-12">
      <h1 class="fw-bold ms-2">Vaults</h1>
      <div class="row">
        <div v-for="v in profileVaults" class="col-3">
          <VaultCard :vault="v" />
        </div>
      </div>
    </div>
    <div class="col-12">
      <h1 class="fw-bold ms-2">Keeps</h1>
      <div class="w-100 columns p-2">
        <div class="p-2" v-for="k in profileKeeps" :key="k.id">
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
import { onMounted } from 'vue';
import Pop from '../utils/Pop.js';
import { profilesService } from "../services/ProfilesService.js"
import { useRoute } from 'vue-router';
import { computed } from '@vue/reactivity';
import { AppState } from "../AppState.js"
import ProfileDetails from '../components/ProfileDetails.vue';
import VaultCard from '../components/VaultCard.vue';

export default {
    setup() {
        const route = useRoute();
        async function getProfile() {
            try {
                await profilesService.getProfile(route.params.id);
            }
            catch (error) {
                Pop.error(error, "[Getting Profile]");
            }
        }
        async function getProfileVaults() {
            try {
                await profilesService.getProfileVaults(route.params.id);
            }
            catch (error) {
                Pop.error(error, "[Getting Profile's Vaults]");
            }
        }
        async function getProfileKeeps() {
            try {
                await profilesService.getProfileKeeps(route.params.id);
            }
            catch (error) {
                Pop.error(error, "[Getting Profile's Keeps]");
            }
        }
        onMounted(() => {
            getProfile(),
                getProfileKeeps(),
                getProfileVaults();
        });
        return {
            profile: computed(() => AppState.profile),
            profileVaults: computed(() => AppState.profileVaults),
            profileKeeps: computed(() => AppState.profileKeeps)
        };
    },
    components: { ProfileDetails, VaultCard }
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