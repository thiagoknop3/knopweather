<template>
  <div class="forecastsearch">
    <b-alert
      :show="dismissCountDown"
      v-for="message in messages"
      :key="message.text"
      dismissible
      :variant="message.type"
      @dismissed="dismissCountDown=0"
      @dismiss-count-down="countDownChanged"
    >{{message.text}}</b-alert>

    <b-form-row class="justify-content-md-center" >
      <b-col cols="auto" md="auto" sm="auto">
        <b-form-input
          v-on:keyup.enter="search"
          v-focus
          ref="search"
          type="text"
          v-model.trim="searchParam"
          class="search"
          placeholder="Enter city or zipcode"
          :state="searchParamValidate"
          :maxlength="50"
          :minlength="3"
          @keyup.native.enter="onKeyDown"
        ></b-form-input>
        <b-form-invalid-feedback id="searchParamValidate">Enter at least 3 letters</b-form-invalid-feedback>
      </b-col>
      <b-col cols="auto" md="auto" sm="auto">
        <b-button variant="primary" @click.prevent="search">search</b-button>
      </b-col>
    </b-form-row>

    <img src="../assets/loading.svg" v-if="isLoading">
  </div>
</template>

<script>
import { mapMutations } from "vuex";

export default {
  name: "ForecastSearch",
  data() {
    return {
      searchParam: "",
      validateParam: false,
      isLoading: false,
      messages: [],
      dismissSecs: 5,
      dismissCountDown: 0
    };
  },
  computed: {
    isNumeric() {
      var pattern = /^\d+$/;
      return pattern.test(this.searchParam);
    },
    searchParamValidate() {
      return this.searchParam.length > 2;
    }
  },
  methods: {
    ...mapMutations(["addForecast"]),
    ...mapMutations(["cleanForecast"]),
    search() {
      if (this.searchParam.length < 3) {
        return;
      }
      var city = this.isNumeric ? null : this.searchParam;
      var zipCode = this.isNumeric ? this.searchParam : null;
      this.getForecast(city, zipCode);
    },
    clean() {
      this.messages = [];
      this.cleanForecast();
    },
    async getForecast(city, zipCode) {
      this.isLoading = true;
      this.clean();
      this.$http
        .get("forecast", {
          params: {
            city: city,
            zipCode: zipCode
          }
        })
        .then(res => {
          this.isLoading = false;
          this.addForecast(res.data);
          if (!res.data.city) {
            this.showMessage(
              "City not found. Please inform a valid German city.",
              "warning"
            );            
          }
        })
        .catch(error => {
          this.isLoading = false;
          if (error.response.status === 400) {
            if (error.response.data.errors.zipCode) {
              this.showMessage("Invalid zipCode", "warning");
            }
            if (error.response.data.errors.city) {
              this.showMessage("City is invalid", "warning");
            }
          } else if (error.response.status === 404) {
            this.showMessage("City not found", "warning");
          } else {
            this.showMessage("Communication error with the server.", "danger");
          }
        });
    },
    showMessage(message, type) {
      this.messages.push({
        text: message,
        type: type
      });
      this.dismissCountDown = this.dismissSecs;
    },
    countDownChanged(dismissCountDown) {
      this.dismissCountDown = dismissCountDown;
    },
    onKeyDown(event) {
      if (event.which === 13) {
        this.search();       
      }
    }
  }
};
</script>

<style scoped>
.search {
  width: 20rem;
}
.forecastsearch .form-row {
  margin: 1rem;
}
</style>
