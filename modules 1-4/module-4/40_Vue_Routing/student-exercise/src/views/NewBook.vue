<template>
    <div> 
        <new-book-form />
    </div>
</template>

<script>
import NewBookForm from '../components/NewBookForm.vue'

export default {
    name: 'New-Book-View',
    components: {
        NewBookForm
    }
}
</script>