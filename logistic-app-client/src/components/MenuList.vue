<template>
    <div>
        <ul>
            <MenuItem
                v-for="item of menuItems" :key="item.id"
                v-bind:item="item" 
            />
        </ul>
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
            {id:3,title:'Автопарк',url:'/cars'},
            {id:4,title:'Пользователи',url:'/users'},
            {id:5,title:'Справочники',url:'/data'}
        ]
        }
    },
    components:{
        MenuItem
    }    
}
</script>

<style scoped>
    ul {
    list-style:none;
    }
</style>