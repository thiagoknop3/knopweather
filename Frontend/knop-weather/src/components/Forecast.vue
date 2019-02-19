<template>
  <div v-if="forecast" class="forecast">    
    <h3> {{forecast.city}}, {{forecast.country}}</h3>
    <b-row class="justify-content-md-center" v-for="date in forecast.dates" :key="date.date">
      <ForecastDay :date="date"/>
    </b-row>
  </div>
</template>

<script>
import { mapGetters } from "vuex";
import ForecastDay from "../components/ForecastDay.vue";

export default {
  name: "Forecast",
  components: {
    ForecastDay
  },
  computed: {
    ...mapGetters({ forecast: "forecast" })
  }
};
</script>


<style scoped>
.day{
  display: flex;
  align-items: flex-start;
  text-align: center;

  
}
</style>
