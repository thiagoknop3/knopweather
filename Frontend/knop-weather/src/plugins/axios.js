import Vue from 'vue'
import axios from 'axios'
axios.defaults.baseURL = 'http://localhost:5000/api/weather';

Vue.use({
    install(Vue) {
        Vue.prototype.$http = axios;
        Vue.prototype.$http.interceptors.request.use(config => {
            //this.$store.state.isLoading = true;
            return config;
        }, error => Promise.reject(error));

        Vue.prototype.$http.interceptors.response.use(res=>{
            //this.$store.state.isLoading = true;
            return res;
        }, error => Promise.reject(error));
    }
})