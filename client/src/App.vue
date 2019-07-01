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
      <select v-model="comparisonOne.selectedEnv">
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
      <input type="text" v-model="password" />

      <br />
      <label v-if="comparisonOne.hash_verify=='verify'">hashed password</label>
      <input
        type="text"
        v-if="comparisonOne.hash_verify=='verify'"
        v-model="comparisonOne.hashedPassword"
      />

      <br />
      <label v-if="comparisonOne.selectedEnv && comparisonOne.selectedEnv!='bcrypt'">iterations</label>
      <input
        type="number"
        v-if="comparisonOne.selectedEnv && comparisonOne.selectedEnv!='bcrypt'"
        v-model="comparisonOne.iterations"
      />

      <br />
      <label v-if="comparisonOne.selectedEnv && comparisonOne.selectedEnv!='bcrypt'">salt</label>
      <input
        type="text"
        v-if="comparisonOne.selectedEnv && comparisonOne.selectedEnv!='bcrypt'"
        v-model="comparisonOne.salt"
      />

      <br />
      <button v-on:click="sendRequest(1)">Send Request</button>
      <textarea readonly v-model="comparisonOne.response"></textarea>
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

      console.log(temp);
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
