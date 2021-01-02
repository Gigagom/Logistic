<template>
    <div class="help">
        <div class="help__heading">Справка</div>
        <button class="help__close" v-on:click="$emit('helpVision')"><svg xmlns="http://www.w3.org/2000/svg" version="1" viewBox="0 0 24 24"><path d="M13 12l5-5-1-1-5 5-5-5-1 1 5 5-5 5 1 1 5-5 5 5 1-1z"></path></svg></button>
        <tabs>
            <tab title="Вход">
            Вход
            </tab>
            <tab title="Заказы">
            This is React
            </tab>
            <tab title="Автомобили и прицепы">
            This is Svelte
            </tab>
            <tab title="О программе">
            This is Svelte
            </tab>
        </tabs>
    </div>
</template>

<script>
import { Tabs, Tab } from 'vue-slim-tabs'

export default {
  components: {
    Tabs, Tab
  }
}

</script>

<style lang="scss" scope>
.help {
  z-index: 3;
  position: absolute;
  height: 90vh;
  width: 90%;
  left: 50%;
  top: 50%;
  transform: translateX(-50%) translateY(-50%);
  padding: 1.5rem;
  border: 1px solid #EBEBFF;
  border-radius: 0.3rem;
  background-color: #fff;

  &__heading {
    margin: 0;
    font-size: 1.5rem;
    font-weight: 700;
    margin-bottom: 1.2rem;
  }
  &__close {
      position: absolute;
      opacity: .8;
      padding: 10px;
      right: 0;
      top: 0;
      cursor: pointer;
      background: transparent;
      border: 0;
      border-radius: 0;
      box-shadow: none;
      display: inline-block;
      height: 44px;
      vertical-align: top;
      visibility: inherit;
      width: 44px;
      
    &:hover {
      opacity: 1;
    }
  }

  .vue-tablist {
    border-bottom: 1px solid #42D9C8;
    flex-wrap: wrap;
  }
  .vue-tabpanel {
    padding-top: 1rem;
  }
  .vue-tab {
    margin-top: 1px;
    border-radius: 0.37rem 0.37rem 0 0;
    padding: 0.4rem 0.8rem;
    border: 1px solid transparent;
    border-bottom-color: #42D9C8;
    
    &[aria-selected="true"] {
      color: #42D9C8;
      border-color: #42D9C8;
      border-bottom-color: transparent;
      margin-bottom: -1px;
    }
  }
}
</style>
<style scope src="vue-slim-tabs/themes/default.css"></style>