<template>
  <div id="app">
    <MenuList/>
    <Map/>
    <router-view/>
  </div>
</template>

<script>

import MenuList from '@/components/MenuList'
import Map from '@/components/Map'
export default {
  name: 'App',  
  components: {
    MenuList,
    Map
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
