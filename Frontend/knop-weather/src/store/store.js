import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
    state: {
        forecast: [],
        history: [{
            forecast: []
        }],
        isLoading: false
    },
    getters: {
        forecast(state) {
            if (state.forecast && state.forecast.city) {
                return state.forecast;
            }
            return null;
        },
        forecastHistory(state) {
            return state.history;
        }
    },
    mutations: {
        addForecast(state, forecast) {
            state.forecast = forecast;
            if (forecast.city) {
                state.history.push(forecast);
            }
        },
        cleanForecast(state) {
            state.forecast = null;
        },
        isLoading(state, isLoading) {
            state.isLoading = isLoading;
        }
    }
})