<template v-if="date">
  <div class="forecastDay">
    <b-card bg-variant="light" border-variant="info" class="text-center">
      <b-row class="header-day">
        <strong>{{date.date | date}}</strong>
      </b-row>
      <div class="table">
        <b-row class="header">
          <b-col class="header-time">Time</b-col>
          <b-col class="header-temperature">Temperature</b-col>
          <b-col class="header-humidity">Humidity</b-col>
          <b-col class="header-windSpeed">Wind</b-col>
        </b-row>
        <b-row class="row-hour" align-v="center" v-for="hour in date.hours" :key="hour.hour">
          <b-col class="time">{{hour.hour | hour}}</b-col>
          <b-col class="temperature">
            <div class="d-flex flex-column">
              <div class="p2">
                <img class="weather-icon" :src="getWeatherIcon(hour)">
              </div>
              <div class="p2">{{hour.temperature | temperature}}</div>
            </div>
          </b-col>
          <b-col class="humidity">{{hour.humidity | humidity}}</b-col>
          <b-col class="windSpeed">{{hour.windSpeed | windSpeed}}</b-col>
        </b-row>
      </div>
    </b-card>
  </div>
</template>

<script>
export default {
  name: "ForecastDay",

  props: {
    date: null
  },
  methods: {
    getWeatherIcon(hour) {
      let id = hour.weatherId;
      let dayNigth = this.dayNigth(hour.hour);
      if (id >= 200 && id <= 232) {
        return require("../assets/icons/11d.png");
      }
      if (id >= 300 && id <= 321) {
        return require("../assets/icons/09d.png");
      }
      if (id >= 500 && id <= 504) {
        return require("../assets/icons/10d.png");
      }
      if (id >= 511 && id <= 531) {
        return require("../assets/icons/09d.png");
      }
      if (id >= 600 && id <= 622) {
        return require("../assets/icons/13d.png");
      }
      if (id >= 701 && id <= 781) {
        return require("../assets/icons/50d.png");
      }
      if (id === 800) {
        return require(`../assets/icons/01${dayNigth}.png`);
      }
      if (id === 801) {
        return require(`../assets/icons/02${dayNigth}.png`);
      }
      if (id === 802) {
        return require(`../assets/icons/03${dayNigth}.png`);
      }
      if (id === 803 || id === 804) {
        return require(`../assets/icons/04${dayNigth}.png`);
      }
    },
    dayNigth(hour) {
      if (hour > 19) {
        return "n";
      }
      return "d";
    }
  }
};
</script>

<style scoped>
.forecastDay .card {
  margin: 1rem;
  padding: 0;
}
.forecastDay {
  min-width: 20rem;
  width: 50rem;
}

.card-body {
  padding-bottom: 0.2rem;
  padding-top: 1rem;
}

.header {
  box-sizing: border;
  border-bottom: 1px solid #999;
  background-color: #efefef;
  height: auto;
  font-weight: 400;
}

.header-day {
  color: #000;
  margin-bottom: 0.5rem;
  padding: 1px 0 1px 2px;
  border-left: 4px solid #00aeef;
}

.row {
  height: auto;
}

.row-hour {
  border-bottom: 1px solid #dcdcdc;
  color: #555;
  font-weight: 300;
}

.time {
  color: #000;
  font-weight: 500;
}

.temperature {
  font-size: 0.8rem;
  font-weight: 400;
}
.row-hour.weather-icon {
  max-width: 2.8rem;
}
</style>
