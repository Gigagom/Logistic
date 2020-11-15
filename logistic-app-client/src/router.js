import Vue from 'vue'
import Router from 'vue-router'
import Home from '@/views/Home'

Vue.use(Router)

export default new Router({
    mode: 'history',
    routes: [
        {
            path:'/'
        },
        {
            path:'/orders',
            component: () => import('@/views/Orders.vue')
        },
        {
            path:'/cars',
            component: () => import('@/views/Cars.vue')
        },
        {
            path:'/users',
            component: () => import('@/views/Users.vue')
        },
        {
            path:'/data',
            component: () => import('@/views/Data.vue')
        }
    ]
})