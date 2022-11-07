<template>
  <section class="container-fluid">
    <div class="row">
      <div class="col-12 columns p-2">
        <div class="p-2" v-for="k in keeps" :key="k.id">
          <KeepCard :keep="k" />
        </div>
      </div>
    </div>
  </section>
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
