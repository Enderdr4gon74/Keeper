<template>
  <section v-if="keeps" class="row">
    <div class="col-12 columns p-2">
      <div class="p-2" v-for="k in keeps" :key="k.id">
        <KeepCard :keep="k" />
      </div>
    </div>
  </section>
  <div v-else class="row justify-content-center align-items-center">
    <div class="col-10 col-sm-5">
      <img src="https://media1.giphy.com/media/3o7TKtnuHOHHUjR38Y/giphy.gif?cid=6c09b952um0m52mj4i3ec61o3vz9jy1wu7vcresa4fjvnyeu&rid=giphy.gif&ct=s" alt="loading..." class="img-fluid w-100">
    </div>
  </div>
</template>

<script>
import { onMounted } from 'vue';
import Pop from '../utils/Pop.js';
import { keepsService } from "../services/KeepsService.js"
import { computed } from '@vue/reactivity';
import { AppState } from '../AppState.js';
import KeepCard from '../components/KeepCard.vue';

export default {
    setup() {
        async function getKeeps() {
            try {
                await keepsService.getKeeps();
            }
            catch (error) {
                Pop.error(error, "[Getting Keeps]");
            }
        }
        onMounted(() => {
            getKeeps();
        });
        return {
            keeps: computed(() => AppState.keeps)
        };
    },
    components: { KeepCard }
}
</script>

<style scoped lang="scss">
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
