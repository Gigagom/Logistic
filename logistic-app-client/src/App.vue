<template>
  <div id="app">
    <div class="row">
      <div class="col">
        <MenuList/>
      </div>      
      <div class="col-wide">
        <div class="row">
          <div class="col-2">
            <router-view/>
          </div>        
          <Map/>
        </div> 
      </div> 
    </div>       
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
  width: 100%;
  height: 100%;
  padding: 0;
  margin: 0;
}
div, h1 {
    padding: 0;
    margin: 0;
}
ul{
    list-style:none;
    padding: 0;
    margin: 0;
}
.row {
  display: flex;
  flex-wrap: wrap;
}
.col, .col-wide {
  width: 100%;
  position: relative;
}
.col {
  flex: 0 0 15%;
  max-width: 15%;  
  background-color: gray;
}
.col-2 {
  flex: 0 0 20%;
  max-width: 20%;  
  background-color: whitesmoke;
  height: 100vh;
}
.col-2:empty{
  display: none;
}
.col-wide {
  max-width: 100%;
  flex-grow: 1;
  flex-basis: 0;
  background-color: coral;
}
</style>
