<template>
    <p>
    <a v-bind:href="url">{{headerMessage}}</a>
    </p>
</template>

<script>
export default {
    props: ['headerMessage', 'url']
}
</script>

<style scoped>
    a {
        display: block;
    }
</style>