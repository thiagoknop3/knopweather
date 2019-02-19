import Vue from 'vue'
// Register a global custom directive called `v-focus`
Vue.directive('focus', {
    inserted: function (el) {
      el.focus()
    }
  })