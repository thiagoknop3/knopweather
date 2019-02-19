import Vue from 'vue';
import moment from 'moment';

Vue.filter('date', function (value) {
  if (value) {
    return moment(String(value)).format('DD.MM.YYYY')
  }
})
Vue.filter('hour', function (value) {
  return String(value)+':00'
})