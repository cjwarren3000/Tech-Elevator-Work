<template>
    <div>
        <reading-list />
        <footer> 
            <nav>
                <router-link v-bind:to="{name: 'NewBook'}"> Add a new book! </router-link>
            </nav>
        </footer>
    </div>
</template>

<script>
import ReadingList from '../components/ReadingList.vue'

export default {
    name: 'My-Books',
    components: {
        ReadingList
    }
}
</script>