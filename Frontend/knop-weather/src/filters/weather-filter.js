import Vue from 'vue';

Vue.filter('temperature', function (value) {
    return String(Math.round(value.maxTemperature)) + '° / ' + String(Math.round(value.minTemperature)) + '°'
})
Vue.filter('humidity', function (value) {
    return String(value) + '%'
})
Vue.filter('windSpeed', function (value) {
    return String(value) + ' mt/s'
})