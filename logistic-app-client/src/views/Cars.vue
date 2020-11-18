<template>
    <div class="cars">
        <h1 class="title">Автомобили</h1>
        <input class="cars__search form-control form-control-sm" type="text" placeholder="Поиск" v-model="search">        
        <button class="btn btn-sm btn-secondary cars__btn"  v-on:click.prevent="newCar"><i>&#43;</i><span>Добавить</span></button>
        <Loader v-if="loading"/>
        <ul class="cars-list" v-else-if="searchCars.length">
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
            <form id="CarFrom" class="modal__form" @submit.prevent="onSubmit">           
                <input v-if="car.id" v-model="car.id" type="hidden">
                <div class="form-row">
                  <div class="col form-group">
                    <label for="brand">Брэнд</label>
                    <input class="form-control" name="brand" required v-model="car.brand" type="text">
                  </div>
                  <div class="col form-group">
                    <label for="model">Модель</label>
                    <input class="form-control" name="model" v-model="car.model" type="text">
                  </div>
                </div>
                <div class="form-row">
                  <div class="col form-group">
                    <label for="number">Номер</label>
                    <input class="form-control" name="number" v-model="car.number" type="text">
                  </div>
                  <div class="col form-group">
                    <label for="mileage">Пробег</label>
                    <input class="form-control" name="mileage" v-model="car.mileage" type="number">
                  </div>
                </div>
                <div class="form-row">
                  <div class="col form-group">
                    <label for="fuel_consumption">Расход на 100 км</label>
                    <input class="form-control" name="fuel_consumption" v-model="car.fuel_consumption" type="number">
                  </div>
                </div>
                <input class="btn btn-primary" type="submit" value="Сохранить">
                <button class="modal__form__close" v-on:click.prevent="closeModal"><svg xmlns="http://www.w3.org/2000/svg" version="1" viewBox="0 0 24 24"><path d="M13 12l5-5-1-1-5 5-5-5-1 1 5 5-5 5 1 1 5-5 5 5 1-1z"></path></svg></button>
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
                .finally(() => {                    
                    this.getCars() 
                    this.closeModal()
                })
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
                }).finally(() => {                    
                    this.getCars() 
                    this.closeModal()
                })
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

<style lang="scss">
  
.cars {
  
  &__btn {
    margin-bottom: 8px;
  }
  
  &__search {
    margin-bottom: 1.2rem;
  }
  
  .title {
    margin-bottom: 1.5rem;
  }
}
.modal {
  position: absolute;
  top: 20%;
  left: 50%;
  transform: translateY(-20%) translatex(-50%);
  width: 500px;
  height: auto;
  border: 1px solid #EBEBFF;
  border-radius: 0.3rem;
  background-color: $white;
  padding: 1.5rem;
  
  &__form {
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
      
      &:focus {
        outline: none;
      }
    }
  }
}
</style>