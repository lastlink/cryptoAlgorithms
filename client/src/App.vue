<template>
  <div id="app">
    <img alt="Vue logo" src="./assets/logo.png" />
    <HelloWorld msg="Welcome to Hashing Tester"/>
    <div>
      <label>select an environments</label>
      <select v-model="comparisonOne.selectedEnv">
          <option disabled value="">Please select one</option>
          <option v-for="(option,index) in environments" v-bind:value="option.url" v-bind:key="index">
          {{ option.lang }}:{{ option.framework }}
        </option>
      </select>
      <br>
      <label>algorithm</label>{{comparisonOne.selectedAlgo}}
      <select v-model="comparisonOne.selectedAlgo">
        <option disabled value="">Please select one</option>
        <option>bcrypt</option>
        <option>sha256</option>
      </select>
      <br>
      <label>hashpassword_verify</label>
      <br>
      <label>password</label>
      <br>
      <label>hashed password</label>
      <br>
      <label>iterations</label>
      <br>
      <label>salt</label>
      <br>
    </div>
  </div>
</template>

<script>
import HelloWorld from './components/HelloWorld.vue'

export default {
  name: 'app',
  data: ()=> {
    return {
      comparisonOne:{},
      comparisonOne:{},
      environments:[
        {
          lang:"c#",
          framework:"dotnet.2.x",
          url:"http://localhost:5000/api"
        },
        {
          lang:"php#",
          framework:"laravel5.8",
          url:"http://localhost:8000/api"
        }
      ]

    }
  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
