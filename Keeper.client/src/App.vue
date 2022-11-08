<template>
  <header class="topNav sticky-top">
    <Navbar />
  </header>
  <main class="container-fluid">
    <router-view />
  </main>
  <!-- <footer class="bottomNav bg-dark sticky-bottom pb-5">
    <Navbar />
  </footer> -->
  <!-- SECTION modals -->
  <div>
    <!-- STUB Keep Info Modal -->
    <div class="modal fade" id="KeepModal" tabindex="-1" aria-hidden="true">
      <div class="modal-dialog modal-xl">
        <div class="modal-content">
          <div class="modal-body row px-2-5 py-0">
            <KeepInfo />
          </div>
        </div>
      </div>
    </div>
    <!-- STUB Create Keep Modal -->
    <div class="modal fade" id="CreateKeepModal" tabindex="-1" aria-labelledby="CreateKeepModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h1 class="modal-title fs-5" id="CreateKeepModalLabel">Create Keep</h1>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            <CreateKeepForm />
          </div>
        </div>
      </div>
    </div>
    <!-- STUB Create Vault Modal -->
    <div class="modal fade" id="CreateVaultModal" tabindex="-1" aria-labelledby="CreateVaultModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h1 class="modal-title fs-5" id="CreateVaultModalLabel">Create Vault</h1>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            <CreateVaultForm />
          </div>
        </div>
      </div>
    </div>
    <!-- STUB Edit Account Modal -->
    <div class="modal fade" id="EditAccountModal" tabindex="-1" aria-labelledby="EditAccountModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h1 class="modal-title fs-5" id="EditAccountModalLabel">EditAccount</h1>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            <EditAccountForm />
          </div>
        </div>
      </div>
    </div>
    <!-- STUB Edit Account Modal -->
    <div class="modal fade" id="EditVaultModal" tabindex="-1" aria-labelledby="EditVaultModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h1 class="modal-title fs-5" id="EditVaultModalLabel"> Edit Vault </h1>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            <EditVaultForm />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import CreateKeepForm from './components/CreateKeepForm.vue'
import CreateVaultForm from './components/CreateVaultForm.vue'
import EditAccountForm from './components/EditAccountForm.vue'
import EditVaultForm from './components/EditVaultForm.vue'
import KeepInfo from './components/KeepInfo.vue'
import Navbar from './components/Navbar.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar, KeepInfo, CreateKeepForm, CreateVaultForm, EditAccountForm, EditVaultForm }
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

// .topNav {
//   display: block;
// }

// .bottomNav {
//   display: none;
// }

// @media screen AND (max-width: 960px) {
//   .topNav {
//     display: none;
//   }

//   .bottomNav {
//     display: block;
//   }
// }
</style>
