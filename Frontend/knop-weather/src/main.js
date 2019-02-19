import Vue from 'vue'
// main component
import KnopWheather from './KnopWheather.vue'
//Vuex :)
import store from './store/store'
//pugins
import './plugins/bootstrap-vue'
import './plugins/axios'
//filters
import './filters/date-filter'
import './filters/weather-filter'
//directives
import './directives/v-focus'

Vue.config.productionTip = false

new Vue({
  store,
  render: h => h(KnopWheather),
}).$mount('#knopweather')