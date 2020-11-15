<template>
    <div>
        <h1>Cars</h1>
        <Loader v-if="loading"/>
        <ul v-else-if="CarsList.length">
            <Car
                v-for="car of CarsList" :key="car.id"
                v-bind:car="car" 
            />
        </ul>
        <p v-else>Список пуст</p>
    </div>
</template>

<script>
import Loader from '@/components/Loader'
import Car from '@/components/Car'
export default {
    data(){
        return {
            CarsList:[],
            loading: true
        }
    },
    mounted(){
        fetch('https://localhost:5001/api/cars/')
            .then(response => response.json())
            .then(json => {
                this.CarsList = json
            })
        this.loading = false
    },
    components:{
        Loader, Car
    }   
}
</script>