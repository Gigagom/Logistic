import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)

export default new Router({
    linkActiveClass: 'active',
    linkExactActiveClass: 'exact-active',
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
            path:'/trailers',
            component: () => import('@/views/Trailers.vue')
        },
        {
            path:'/clients',
            component: () => import('@/views/Clients.vue')
        },
        {
            path:'/bordercrossings',
            component: () => import('@/views/BorderCrossings.vue')
        },
        {
            path:'/customs',
            component: () => import('@/views/Customs.vue')
        },
        {
            path:'/declarants',
            component: () => import('@/views/Declarants.vue')
        },
        {
            path:'/users',
            component: () => import('@/views/Users.vue')
        }
    ]
})