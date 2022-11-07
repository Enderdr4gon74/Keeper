<template>
  <header>
    <Navbar />
  </header>
  <main class="container-fluid">
    <router-view />
  </main>
  <div class="modal fade" id="KeepModal" tabindex="-1" aria-hidden="true">
    <div class="modal-dialog modal-xl">
      <div class="modal-content">
        <div class="modal-body row px-2-5 py-0">
          <KeepInfo />
        </div>
      </div>
    </div>
  </div>
   <!-- <footer class="bg-dark text-light">
    Made with 💖 by CodeWorks
  </footer> -->
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import KeepInfo from './components/KeepInfo.vue'
import Navbar from './components/Navbar.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar, KeepInfo }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root{
  --main-height: calc(100vh - 32px - 64px);
}


footer {
  display: grid;
  place-content: center;
  height: 32px;
}

.px-2-5 {
  padding-left: 0.75rem;
  padding-right: 0.75rem;
}
</style>
