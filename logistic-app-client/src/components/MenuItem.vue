<template>
    <li>
        <router-link :to=item.url>{{item.title}}</router-link>
    </li>
</template>

<script>
export default {
    props:{
        item:{
            type: Object,
            required: true
        }
    }
}
</script>