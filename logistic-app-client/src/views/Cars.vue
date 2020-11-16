<template>
    <div>
        <h1>Cars</h1>
        <input type="text" placeholder="Поиск" v-model="search">        
        <button  v-on:click.prevent="newCar">Добавить</button>
        <Loader v-if="loading"/>
        <ul v-else-if="searchCars.length">
            <Car
                v-for="(car, i) of searchCars" :key="car.id"
                v-bind:car="car" 
                v-bind:index="i"
                @remove-car="removeCar"
                @get-car="getCar"
            />
        </ul>
        <p v-else>Список пуст</p>
        <div v-if="carForm" class="modal">
            <form id="CarFrom" @submit.prevent="onSubmit">                
                <input v-if="car.id" v-model="car.id" type="hidden">
                <label for="brand">Брэнд</label>
                <input name="brand" required v-model="car.brand" type="text">
                <label for="model">Модель</label>
                <input name="model" v-model="car.model" type="text">
                <label for="number">Номер</label>
                <input name="number" v-model="car.number" type="text">
                <label for="mileage">Пробег</label>
                <input name="mileage" v-model="car.mileage" type="number">
                <label for="fuel_consumption">Расход на 100 км</label>
                <input name="fuel_consumption" v-model="car.fuel_consumption" type="number">
                <input type="submit" value="Сохранить">
                <button v-on:click.prevent="closeModal">Закрыть</button>
            </form>
        </div>
    </div>
</template>

<script>
import Loader from '@/components/Loader'
import Car from '@/components/Car'
export default {
    data(){
        return {
            CarsList:[],
            loading: true,
            carForm:false,
            car:{id:null,brand:null,model:null,number:null,mileage:null,fuel_consumption:null},
            search:""
        }
    },
    computed:{
        searchCars(){
            if(this.search.length){
                return this.CarsList.filter(c => c.brand.toLowerCase().startsWith(this.search.toLowerCase()) || c.model.toLowerCase().startsWith(this.search.toLowerCase()) || c.number.toLowerCase().startsWith(this.search.toLowerCase()))
            }else{
                return this.CarsList
            }
        }
    },
    methods:{
        removeCar(id){
            fetch('https://localhost:5001/api/cars/'+id, { method: 'DELETE'})
            this.CarsList = this.CarsList.filter(c => c.id !== id)
        },
        getCars(){
           fetch('https://localhost:5001/api/cars/',{
               headers: {
                    'Cache-Control': 'no-cache'
                }
           })
            .then(response => response.json())
            .then(json => {
                this.CarsList = json                
                this.loading = false
            })
        },
        getCar(id){
            fetch('https://localhost:5001/api/cars/'+id)
            .then(response => response.json())
            .then(json => {
                this.car = json;
            }).finally(()=>this.openModal())
        },
        newCar(){
            this.car = {id:null,brand:null,model:null,number:null,mileage:null,fuel_consumption:null};
            this.openModal()
        },
        openModal(){
            this.carForm = true;
        },
        closeModal(){
            this.carForm = false;
            this.car = {id:null,brand:null,model:null,number:null,mileage:null,fuel_consumption:null};
        },
        onSubmit(){
            if(this.car.id){
                fetch('https://localhost:5001/api/cars/'+this.car.id, 
                { 
                    method: 'PUT',
                    body: JSON.stringify(this.car, function(key, value){
                        if(key === "mileage" || key === "fuel_consumption"){
                            return parseFloat(value)
                        }                        
                        return value
                    }),
                    headers: {
                        'Content-Type': 'application/json'
                    }
                })
                .then(response => console.log(response))
                .finally(() =>  
                    this.getCars(), 
                    this.closeModal()  
                ) 
            }else{
                fetch('https://localhost:5001/api/cars/', 
                { 
                    method: 'POST',
                    body: JSON.stringify(this.car, function(key, value){
                        if(key === "mileage" || key === "fuel_consumption"){
                            return parseFloat(value)
                        }                        
                        return value
                    }),
                    headers: {
                        'Content-Type': 'application/json'
                    }
                })
                .then(response => response.json())
                .then(json => {
                    console.log(json);
                }).finally(() =>   
                    this.getCars(), 
                    this.closeModal()  
                )
            }
            
        }
    },
    mounted(){
        this.getCars()
    },
    components:{
        Loader, Car
    } 
}
</script>

<style>
.modal {
    position: absolute;
    top: 20%;
    left: 50%;
    transform: translateY(-20%) translatex(-50%);
    width: 500px;
    height: 300px;
    border: 1px solid #000;
}
</style>