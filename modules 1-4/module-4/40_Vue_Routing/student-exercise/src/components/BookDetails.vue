<template>
    <div>
        <book-card v-bind:key="book.isbn"  />
    </div>
</template>

<script>
import BookCard from '../components/BookCard.vue';

export default {
    name: 'Book-Details',
    components: {
        BookCard
    }
}
</script>