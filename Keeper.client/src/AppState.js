import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},

  /** @type {import('./models/Account.js').Account} */
  account: {},

  /** @type {import('./models/Keep.js').Keep[] | null} */
  keeps: null,

  /** @type {import('./models/Keep.js').Keep | null} */
  activeKeep: null,

  /** @type {import('./models/Profile.js').Profile | null} */
  profile: null,

  /** @type {import('./models/Keep.js').Keep[] | null} */
  profileKeeps: null,

  /** @type {import('./models/Vault.js').Vault[] | null} */
  profileVaults: null,

  /** @type {import('./models/Vault.js').Vault | null} */
  vault: null,

  /** @type {import('./models/VaultKeep.js').VaultKeep[] | null} */
  vaultKeeps: null,
})
