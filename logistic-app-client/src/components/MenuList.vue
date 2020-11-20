<template>
    <div>
        <ul class="menu-list">
            <MenuItem
                v-for="item of menuItems" :key="item.id"
                v-bind:item="item" 
            />
        </ul>
        <button  v-on:click.prevent="Logout">Выйти</button>
    </div>
</template>

<script>
import  MenuItem from '@/components/MenuItem'
export default {
    data(){
        return {
        menuItems:[
            {id:1,title:'Главная',url:'/'},
            {id:2,title:'Заказы',url:'/orders'},
            {id:3,title:'Автомобили',url:'/cars'},
            {id:4,title:'Прицепы',url:'/trailers'},
            {id:5,title:'Клиенты',url:'/clients'},
            {id:6,title:'Пункты пропуска',url:'/bordercrossings'}, 
            {id:7,title:'Таможни',url:'/customs'},       
            {id:8,title:'Декларанты',url:'/declarants'},         
            {id:9,title:'Пользователи',url:'/users'}
        ]
        }
    },
    components:{
        MenuItem
    },
    methods:{
        Logout(){
            localStorage.setItem('jwt',null)
            this.$router.push('/login')
        }
    }    
}
</script>

<style lang="scss" scoped>
ul {
  list-style:none;
}
.menu-list {
  margin-top: 80px;
}
</style>