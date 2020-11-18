<template>
    <li class="cars-item">
        <span class="cars-item__info" v-on:click="$emit('get-car', car.id)">
            <strong>{{index+1}}</strong>
            {{car.brand}} {{car.model}} <br> <span class="cars-item__info__number">{{car.number}}</span>
        </span>
        <button class="btn cars-item__close" v-on:click="$emit('remove-car', car.id)">&times;</button>
    </li>
</template>

<script>
export default {
    props:{
        car:{
            type: Object,
            required: true
        },
        index: Number
    }
}
</script>

<style lang="scss" scoped>
.cars-item {
  border: 1px solid $gray;
  border-radius: 0rem;
  background-color: $white;
  display: flex;
  justify-content: space-between;
  padding: 12px 12px;
  border-radius: 0.2rem;
  
  + .cars-item {
    margin-top: 8px;
  }
  
  &__info {
    &__number {
      font-size: 0.9rem;
    }
  }
  
  &__close {
    color: $primary;
    font-size: 1.3rem;
    line-height: 0.5;
    padding: 5px;
    cursor: pointer;
    border-radius: 0.3rem;
    
    &:focus {
      box-shadow: 0 0 0 0.2rem rgba($primary-light, 0.25);
    }
  }
}
</style>