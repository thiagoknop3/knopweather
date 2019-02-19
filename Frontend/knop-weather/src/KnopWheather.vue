<template>
  <div id="knopweather">
    <b-container>
      <b-navbar
        toggleable="md"
        type="dark"
        variant="secondary"
        bg-gradient-primary
        class="bg-gradient-primary"
      >
        <b-navbar-brand href="#">
          <img src="./assets/logo.svg" class="logo-brand">
          KnopWeather
        </b-navbar-brand>
      </b-navbar>
      <div id="content" class="content">
        <ForecastSearch/>
        <Forecast/>
      </div>
    </b-container>
  </div>
</template>

<script>
import ForecastSearch from "./components/ForecastSearch.vue";
import Forecast from "./components/Forecast.vue";
export default {
  name: "knopweather",
  components: {
    ForecastSearch,
    Forecast
  }
};
</script>

<style>
#knopweather {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
.logo-brand{
  max-width: 5rem;
}
.navbar{
  background: url("./assets/bg-clouds.jpg");
  background-position: 0rem -2rem;
	background-repeat: repeat-x;
}
</style>
