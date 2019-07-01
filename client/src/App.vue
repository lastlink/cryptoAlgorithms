<template>
  <div id="app">
    <img alt="Vue logo" src="./assets/logo.png" />
    <HelloWorld msg="Welcome to Hashing Tester" />
    <div>
      <label>select an environments</label>
      <select v-model="comparisonOne.selectedEnv">
        <option disabled value>Please select one</option>
        <option
          v-for="(option,index) in environments"
          v-bind:value="option.url"
          v-bind:key="index"
        >{{ option.lang }}:{{ option.framework }}</option>
      </select>
      <br />
      <label>algorithm</label>
      <select v-model="comparisonOne.algorithm">
        <option disabled value>Please select one</option>
        <option>bcrypt</option>
        <option>sha256</option>
      </select>
      <br />
      <label>hashpassword_verify</label>
      <select v-model="comparisonOne.hash_verify">
        <option disabled value>Please select one</option>
        <option>hash</option>
        <option>verify</option>
      </select>

      <br />
      <label>password</label>
      <input type="text" v-model="comparisonOne.password" />

      <br />
      <label v-if="comparisonOne.hash_verify=='verify'">hashed password</label>
      <input
        type="text"
        v-if="comparisonOne.hash_verify=='verify'"
        v-model="comparisonOne.hashedPassword"
      />

      <br />
      <label v-if="comparisonOne.algorithm && comparisonOne.algorithm!='bcrypt'">iterations</label>
      <input
        type="number"
        v-if="comparisonOne.algorithm && comparisonOne.algorithm!='bcrypt'"
        v-model="comparisonOne.iterations"
      />

      <br />
      <label v-if="comparisonOne.algorithm && comparisonOne.algorithm!='bcrypt'">salt</label>
      <input
        type="text"
        v-if="comparisonOne.algorithm && comparisonOne.algorithm!='bcrypt'"
        v-model="comparisonOne.salt"
      />

      <br />
      <button v-on:click="sendRequest(1)">Send Request</button>
       <pre v-if="comparisonOne.response">{{ comparisonOne.response | pretty }}</pre>
    </div>
  </div>
</template>

<script>
import HelloWorld from "./components/HelloWorld.vue";

export default {
  name: "app",
  data: () => {
    return {
      comparisonOne: {},
      comparisonTwo: {},
      environments: [
        {
          lang: "c#",
          framework: "dotnet.2.x",
          url: "http://localhost:5000/api"
        },
        {
          lang: "php#",
          framework: "laravel5.8",
          url: "http://localhost:8000/api"
        }
      ]
    };
  },
  methods: {
    sendRequest: function(compareNum) {
      var temp = null;
      if (compareNum == 1) temp = this.comparisonOne;
      else temp = this.comparisonTwo;

      // var request
      console.log(temp);
      return this.$http
        .post(temp.selectedEnv+`/hashes`, temp, {
          cache: "no-cache",
          headers: {
            "Content-Type": "application/json"
          }
        })
        .then(response => {
          this.loading = false;
          console.log(response)
          // this.message = response.data.message;
          if (response.status === 200) {
            // console.log(JSON.parse(JSON.stringify(response.data)))
            var resources = response.body;

          
            this.comparisonOne.response = resources;
            // this.comparisonOne = JSON.parse(JSON.stringify(this.comparisonOne))
            console.log(this.comparisonOne.response)
          } else {
            this.errors = "Failed to Load";
          }
        })
        .catch(error => {
          this.errors = "Failed to Retrieve issues";
          console.log(error);
          this.loading = null;
        });
    },
  },
  filters: {
    pretty: function(value) {
      // console.log(value)
      // return value;
      return JSON.stringify(value);
    }
  }
};
</script>

<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
