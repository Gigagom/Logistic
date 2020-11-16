<template>
    <li>
        <span v-on:click="$emit('get-car', car.id)">
            <strong>{{index+1}}</strong>
            {{car.brand}} {{car.model}} <br> {{car.number}}
        </span>
        <button v-on:click="$emit('remove-car', car.id)">&times;</button>
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

<style scoped>
li{
    border: 1px solid #ccc;
    display: flex;
    justify-content: space-between;
    padding: .1rem 1rem;
    margin-bottom: .1rem;
}
</style>