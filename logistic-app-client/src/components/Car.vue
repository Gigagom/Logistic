<template>
    <li>
        {{car}}
    </li>
</template>

<script>
export default {
    props:{
        car:{
            type: Object,
            required: true
        }
    }
}
</script>